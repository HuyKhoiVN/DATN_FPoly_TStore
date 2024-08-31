using AppData.Models;

namespace AppAPI.Repositories.EntityInterface
{
    public interface IRefreshTokenRepository : IBaseRepository<RefreshToken>
    {
        Task<RefreshToken> GetRefreshTokenAsync(string RefreshTokenDto);
    }
}
