

namespace Ecommerce.BusinessLogic.ViewModels 
{

    public class OrderViewModel {
        public string OrderId { get; set; } = null!;
        public string? UserId { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal? TotalPrice { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
        public string? OrderStatus { get; set; }
        public string? Address { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
        public string? Country { get; set; }
        public string? Method { get; set; }
        public string? Comment { get; set; }
    }

}
