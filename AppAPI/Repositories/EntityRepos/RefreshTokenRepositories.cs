using AppAPI.Repositories.EntityInterface;
using AppData.Context;
using AppData.Models;
using Microsoft.EntityFrameworkCore;

namespace AppAPI.Repositories.EntityRepos
{
    public class RefreshTokenRepositories : BaseRepository<RefreshToken>, IRefreshTokenRepository
    {
        public RefreshTokenRepositories(TStoreDb context) : base(context)
        {
        }

        public async Task<RefreshToken> GetRefreshTokenAsync(string RefreshTokenDto)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Token == RefreshTokenDto);
        }
    }
}
