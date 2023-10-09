

namespace Ecommerce.BusinessLogic.RequestModels.Order 
{

   public class CreateOrderRequestModel {
        public string? UserId { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
        public string? Address { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
        public string? Country { get; set; }
        public string? Method { get; set; }
        public int? Rating { get; set; }
        public string? Comment { get; set; }
    }

}
