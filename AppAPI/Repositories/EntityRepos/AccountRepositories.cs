using AppAPI.Repositories.EntityInterface;
using AppData.Context;
using AppData.Models;
using Microsoft.EntityFrameworkCore;

namespace AppAPI.Repositories.EntityRepos
{
    public class AccountRepositories : BaseRepository<Account>, IAccountRepository
    {
        public AccountRepositories(TStoreDb context) : base(context)
        {
        }

        public async Task<Account?> GetByEmailAndPasswordAsync(string email, string password)
        {
            return await _dbSet.Include(r => r.Role).FirstOrDefaultAsync(a => a.Email == email && a.Password == password);
        }
    }
}
