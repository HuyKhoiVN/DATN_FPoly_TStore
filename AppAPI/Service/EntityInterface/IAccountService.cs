using AppAPI.DtoModels;
using AppData.Models;

namespace AppAPI.Service.EntityInterface
{
    public interface IAccountService
    {
        Task<TokenDto> LoginAsync(LoginRequestDto loginRequest);
        Task<TokenDto> GenerateTokenAsync(Account account);
    }
}
