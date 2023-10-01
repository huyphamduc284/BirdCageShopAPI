

namespace Ecommerce.BusinessLogic.ViewModels 
{

    public class VoucherViewModel {
        public string? VoucherId { get; set; }
        public int Point { get; set; }
        public string? Discount { get; set; }
        public string? CouponCode { get; set; }
        public DateTime ExpirationDate { get; set; }

    }

}
