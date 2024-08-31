using AppAPI.Repositories.EntityInterface;
using AppData.Context;
using AppData.Models;
using Microsoft.EntityFrameworkCore;

namespace AppAPI.Repositories.EntityRepos
{
    public class BillDetailRepositories : BaseRepository<BillDetail>, IBillDetailRepository
    {
        public BillDetailRepositories(TStoreDb context) : base(context)
        {
        }

        public async Task<IEnumerable<BillDetail>> GetBillDetailsByBillIdAsync(Guid billId)
        {
            var data = await _dbSet.Where(bd => bd.IdBill == billId).ToListAsync();
            return data;
        }
    }
}
