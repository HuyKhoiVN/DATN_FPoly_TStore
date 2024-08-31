using AppData.Models;
using Microsoft.EntityFrameworkCore;

namespace AppAPI.Repositories.EntityInterface
{
    public interface IBillRepository : IBaseRepository<Bill>
    {
        string GenerateBillCode();
    }
}
