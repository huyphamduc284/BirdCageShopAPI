

namespace Ecommerce.BusinessLogic.RequestModels.OrderDetail 
{

   public class CreateOrderDetailRequestModel {
     
        public string? OrderId { get; set; }
        public string? ProductId { get; set; }
        public int? Quantity { get; set; }
    }

}
