

using BirdCageShop.DataAccess.Repositories;
using Ecommerce.BusinessLogic.RequestModels.Voucher;
using Ecommerce.BusinessLogic.ViewModels;
using BirdCageShop.DataAccess.Models;

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
            var newVoucher = new Voucher
            {
                Point = voucherCreate.Point,
                Discount = voucherCreate.Discount,
                CouponCode = voucherCreate.CouponCode,
                ExpirationDate = voucherCreate.ExpirationDate,
            };
            var createdVoucher = _voucherRepository.Create(newVoucher);
            var voucherViewModel = new VoucherViewModel
            {
                VoucherId = voucherCreate.VoucherId,
                Point = voucherCreate.Point,
                Discount = voucherCreate.Discount,
                CouponCode = voucherCreate.CouponCode,
                ExpirationDate = voucherCreate.ExpirationDate,
            };
            return voucherViewModel;

            throw new NotImplementedException();
        }

        public VoucherViewModel UpdateVoucher(UpdateVoucherRequestModel voucherUpdate) 
        {
            var existingVoucher = _voucherRepository.Get(voucherUpdate.VoucherId);
            if (existingVoucher == null)
            {
                return null;
            }
            existingVoucher.Point = voucherUpdate.Point;
            existingVoucher.Discount = voucherUpdate.Discount;
            existingVoucher.CouponCode = voucherUpdate.CouponCode;
            existingVoucher.ExpirationDate = voucherUpdate.ExpirationDate;

            var updatedVoucher = _voucherRepository.Update(existingVoucher);
            var voucherViewModel = new VoucherViewModel
            {
                VoucherId = voucherUpdate.VoucherId,
                Point = (int)updatedVoucher.Point,
                Discount = voucherUpdate.Discount,
                CouponCode = voucherUpdate.CouponCode,
                ExpirationDate = voucherUpdate.ExpirationDate,
            };
            return voucherViewModel;
            throw new NotImplementedException();
        }

        public bool DeleteVoucher(int idTmp)
        {
            var existingVoucher = _voucherRepository.GetById(idTmp);
            if (existingVoucher == null)
            {
                return false;
            }
            _voucherRepository.Delete(existingVoucher);
            return true;
            throw new NotImplementedException();
        }

        public List<VoucherViewModel> GetAll() 
        {
            // lấy danh sách voucher từ Database
            var vouchers = _voucherRepository.GetAll().Cast<Voucher>();

            // Chuyển đổi danh sách Voucher thành danh sáhc VoucherViewModel
            var voucherViewModels = new List<VoucherViewModel>();
            foreach (var voucher in vouchers)
            {
                var voucherViewModel = new VoucherViewModel
                {
                    VoucherId = voucher.VoucherId,
                    Point = voucher.Point,
                    Discount = voucher.Discount,
                    CouponCode = voucher.CouponCode,
                    ExpirationDate = voucher.ExpirationDate,
                };
                voucherViewModels.Add(voucherViewModel);

            }
            return voucherViewModels;
            throw new NotImplementedException();
        }

        public VoucherViewModel GetById(int idTmp) 
        {
            var voucher = _voucherRepository.GetById(idTmp);
            if (voucher == null)
            {
                return null;
            }
            var voucherViewModel = new VoucherViewModel
            {
                VoucherId = voucher.VoucherId,
                Point = voucher.Point,
                Discount = voucher.Discount,
                CouponCode = voucher.CouponCode,
                ExpirationDate = voucher.ExpirationDate,
            };
            throw new NotImplementedException();
        }

    }

}
