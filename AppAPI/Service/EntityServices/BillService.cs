using AppAPI.DtoModels;
using AppAPI.Repositories;
using AppAPI.Repositories.EntityInterface;
using AppAPI.Service.EntityInterface;
using AppData.Models;

namespace AppAPI.Service.EntityServices
{
    public class BillService : BaseServices<Bill>, IBillService
    {
        private readonly IBillRepository _billRepository;
        private readonly IBillDetailRepository _billDetailRepository;

        public BillService(IBaseRepository<Bill> repository,IBillRepository billRepository, IBillDetailRepository billDetailRepository) : base(repository)
        {
            _billRepository = billRepository;
            _billDetailRepository = billDetailRepository;
        }
        
    }
}
