using AppAPI.DtoModels;
using AppAPI.Repositories;
using AppAPI.Repositories.EntityInterface;
using AppAPI.Service.EntityInterface;
using AppData.Exceptions;
using AppData.Models;
using Microsoft.IdentityModel.Tokens;
using NuGet.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace AppAPI.Service.EntityServices
{
    public class AccountServices : BaseServices<Account>, IAccountService
    {
        private readonly IConfiguration _configuration;
        private readonly IAccountRepository _accountRepository;
        private readonly IBaseRepository<Role> _roleRepository;
        private readonly IRefreshTokenRepository _refreshTokenRepository;      

        public AccountServices(IBaseRepository<Account> repository, IBaseRepository<Role> roleRepository,
                               IRefreshTokenRepository refreshTokenRepository,
                               IConfiguration configuration, IAccountRepository accountRepository) : base(repository)
        {
            _configuration = configuration;
            _accountRepository = accountRepository;
            _roleRepository = roleRepository;
            _refreshTokenRepository = refreshTokenRepository;
        }

        /// <summary>
        /// Login Service
        /// </summary>
        /// <param name="loginRequest">Login Model bao gồm: Username, password</param>
        /// <returns>Model Token của Request</returns>
        /// <exception cref="UnauthorizedAccessException"></exception>
        public async Task<TokenDto> LoginAsync(LoginRequestDto loginRequest)
        {
            // 1. Tìm user theo username, password, không có báo lỗi
            var user = await _accountRepository.GetByEmailAndPasswordAsync(loginRequest.Username, loginRequest.Password);

            if (user == null || user.TokenResetPassword != null)
            {
                throw new UnauthorizedAccessException("Invalid credentials or account is resetting password.");
            }

            // 2. Tạo token
            var token = await GenerateTokenAsync(user);
            return token;
        }

        /// <summary>
        /// Tạo mới token khi token cũ hết hạn
        /// </summary>
        /// <param name="model">Model Token đầu vào</param>
        /// <returns>Token mới</returns>
        /// <exception cref="SecurityTokenException"></exception>
        /// <exception cref="UnauthorizedAccessException"></exception>
        public async Task<TokenDto> RenewTokenAsync(TokenDto model)
        {
            // Khởi tạo mới jwtTokenHandler, secretKeyBytes
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKeyBytes = Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]);

            // Tạo mới TokenValidationParameters để cấu hình kiểm tra AccessToken
            var tokenValidateParam = new TokenValidationParameters
            {
                // Không kiểm tra Issuer, Audience vì không sử dụng
                ValidateIssuer = false,
                ValidateAudience = false,

                // Kiểm tra chữ ký token
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes), // Sử dụng từ khoá bí mật để ktra
                ClockSkew = TimeSpan.Zero, // Không được lệch thời gian
                ValidateLifetime = false // Không kiểm tra thời gian hết hạn
            };

            try
            {
                // 1. Kiểm tra tính hợp lệ của token
                var tokenInVerification = jwtTokenHandler.ValidateToken(model.AccessTokenDto, tokenValidateParam, out var validatedToken);

                // 2. Kiểm tra thuật toán mã hoá (HmacSha512)
                if (validatedToken is JwtSecurityToken jwtSecurityToken)
                {
                    var result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha512, StringComparison.InvariantCultureIgnoreCase);
                    if (!result)
                    {
                        throw new SecurityTokenException("Invalid token algorithm");
                    }
                }

                // 3. Kiểm tra thời gian hết hạn của Access Token
                var utcExpireDate = long.Parse(tokenInVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp).Value);
                var expireDate = ConvertUnixTimeToDateTime(utcExpireDate);

                if (expireDate > DateTime.UtcNow) // Ném ra Exception nếu còn thời hạn
                {
                    throw new SecurityTokenException("Access token has not yet expired");
                }

                // 4. Kiểm tra token có trong db
                var storedToken = await _refreshTokenRepository.GetRefreshTokenAsync(model.RefreshTokenDto);
                if (storedToken == null)
                {
                    throw new SecurityTokenException("Refresh token does not exist");
                }

                // 5. Có thể tách thành 2 func: Đã được sử dụng hoặc đã bị thu hồi
                if (storedToken.IsUsed || storedToken.IsRevoked)
                {
                    throw new SecurityTokenException("Refresh token has been used or revoked");
                }

                // 6. Kiểm tra sự tương thích giữa AcessToken, RefreshToken
                var jti = tokenInVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value;
                if (storedToken.JwtId != jti)
                {
                    throw new SecurityTokenException("Token doesn't match");
                }

                // Kiểm tra xong đánh dấu đã sử dụng, đã thu hồi
                storedToken.IsRevoked = true;
                storedToken.IsUsed = true;
                // 7. Cập nhật
                await _refreshTokenRepository.UpdateAsync(storedToken.Id, storedToken);

                // 8. Tạo token mới, lấy ra account theo Id từ Token, thực hiện gen token từ account
                var user = await _accountRepository.GetByIdAsync(storedToken.AccountId);
                var token = await GenerateTokenAsync(user);

                return token;
            }
            catch (Exception ex)
            {
                throw new UnauthorizedAccessException("Token renewal failed", ex);
            }
        }

        public async Task<TokenDto> GenerateTokenAsync(Account account)
        {
            // 1. Khởi tạo jwtTokenHanler: creating and validating Json Web Tokens
            var jwtTokenHanlder = new JwtSecurityTokenHandler();
            var secretKeyBytes = Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]);

            var role = account.Role;
            if (role == null)
            {
                role = await _roleRepository.GetByIdAsync(account.IdRole);
            }

            // 2. Cấu hình token với các claims và các thông tin cần thiết: username, email, jwtID, userId, role
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name, account.Username),
                new Claim(JwtRegisteredClaimNames.Email, account.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // JWT ID (Jti).
                new Claim("Id", account.Id.ToString()),
                new Claim("IdRole", account.IdRole.ToString()),
                new Claim(ClaimTypes.Role, role.Name),
            }),
                Expires = DateTime.UtcNow.AddMinutes(20), // Thời gian hết hạn của token là 20 phút.
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha512Signature) // Sử dụng thuật toán HmacSha512 để ký token.
            };

            // SecurityToken
            SecurityToken token = jwtTokenHanlder.CreateToken(tokenDescription); 

            var accessToken = jwtTokenHanlder.WriteToken(token);

            // Tạo giá trị của refreshToken ngẫu nhiên
            var refreshToken = GenerateRefreshToken();

            // Tạo ra 1 refreshToken mới và thêm vào db
            var refreshTokenEntity = new RefreshToken
            {
                Id = Guid.NewGuid(), // ID mới
                JwtId = token.Id, // ID của jwt
                AccountId = account.Id, // AccountID
                Token = refreshToken, // Token
                IsUsed = false, // Chưa được sử dụng
                IsRevoked = false, // Chưa bị thua hồi
                IssuedAt = DateTime.UtcNow, // Bắt đầu: now
                ExpiredAt = DateTime.UtcNow.AddHours(1) // kết thúc: now + 1h
            };

            await _refreshTokenRepository.CreateAsync(refreshTokenEntity);
            var tokenDto = new TokenDto
            {
                AccessTokenDto = accessToken,
                RefreshTokenDto = refreshToken
            };
            return tokenDto;
        }

        /// <summary>
        /// Tạo ra 1 chuỗi Base64 ngẫu nhiên bằng cách sử dụng random number, điền chúng vào mảng 32bit và chuyển sang Base64String
        /// </summary>
        /// <returns></returns>
        private string GenerateRefreshToken()
        {
            // 1. Tạo 1 mảng 32bit
            var random = new byte[32];
            using (var rng = RandomNumberGenerator.Create()) // 2. Tạo giá trị ngẫu nhiên cho random number
            {
                rng.GetBytes(random); // 3. Điền mảng với các byte ngẫu nhiên.
                return Convert.ToBase64String(random); // 4. Chuyển mảng byte thành chuỗi Base64.
            }
        }

        private DateTime ConvertUnixTimeToDateTime(long utcExpireDate)
        {
            var dateTimeInterval = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return dateTimeInterval.AddSeconds(utcExpireDate).ToUniversalTime();
        }
    }
}
