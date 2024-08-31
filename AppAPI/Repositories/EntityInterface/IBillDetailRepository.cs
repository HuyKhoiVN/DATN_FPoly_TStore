using AppData.Models;

namespace AppAPI.Repositories.EntityInterface
{
    public interface IBillDetailRepository : IBaseRepository<BillDetail>
    {
        Task<IEnumerable<BillDetail>> GetBillDetailsByBillIdAsync(Guid billId);
    }
}
