

using BirdCageShop.DataAccess.Repositories;
using Ecommerce.BusinessLogic.RequestModels.Voucher;
using Ecommerce.BusinessLogic.ViewModels;

namespace BirdCageShop.BusinessLogic.Services 
{

    public interface IVoucherService {
        public VoucherViewModel CreateVoucher(CreateVoucherRequestModel voucherCreate);
        public VoucherViewModel UpdateVoucher(UpdateVoucherRequestModel voucherUpdate);
        public bool DeleteVoucher(int idTmp);
        public List<VoucherViewModel> GetAll();
        public VoucherViewModel GetById(int idTmp);
    }

    public class VoucherService : IVoucherService {

      private readonly IVoucherRepository _voucherRepository;

        public VoucherService(IVoucherRepository voucherRepository)
        {
            _voucherRepository = voucherRepository;
        }

        public VoucherViewModel CreateVoucher(CreateVoucherRequestModel voucherCreate)
        {
            throw new NotImplementedException();
        }

        public VoucherViewModel UpdateVoucher(UpdateVoucherRequestModel voucherUpdate) 
        {
            throw new NotImplementedException();
        }

        public bool DeleteVoucher(int idTmp)
        {
            throw new NotImplementedException();
        }

        public List<VoucherViewModel> GetAll() 
        {
            throw new NotImplementedException();
        }

        public VoucherViewModel GetById(int idTmp) 
        {
            throw new NotImplementedException();
        }

    }

}
