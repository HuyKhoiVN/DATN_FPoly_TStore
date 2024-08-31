using AppData.Models;

namespace AppAPI.Repositories.EntityInterface
{
    public interface IAccountRepository : IBaseRepository<Account>
    {
        Task<Account?> GetByEmailAndPasswordAsync(string email, string password);
    }
}
