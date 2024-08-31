using AppAPI.Repositories.EntityInterface;
using AppData.Context;
using AppData.Models;
using Microsoft.EntityFrameworkCore;

namespace AppAPI.Repositories.EntityRepos
{
    public class BillRepositories : BaseRepository<Bill>, IBillRepository
    {
        public BillRepositories(TStoreDb context) : base(context)
        {
        }

        public string GenerateBillCode()
        {
            string generatedCode;
            do
            {
                var random = new Random();
                int randomNumber = random.Next(100000, 999999);
                generatedCode = $"HD{randomNumber}";
            }
            while (_dbSet.Any(b => b.Code == generatedCode));
            return generatedCode;
        }
    }
}
