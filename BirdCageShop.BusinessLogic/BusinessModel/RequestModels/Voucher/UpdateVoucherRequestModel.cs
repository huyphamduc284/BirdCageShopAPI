

namespace Ecommerce.BusinessLogic.RequestModels.Voucher 
{

   public class UpdateVoucherRequestModel {
        public int? Point { get; internal set; }
        public string VoucherId { get; set; } = null!;
        public string? Discount { get; set; }
        public string? CouponCode { get; set; }
        public DateTime ExpirationDate { get; set; }

    }

}
