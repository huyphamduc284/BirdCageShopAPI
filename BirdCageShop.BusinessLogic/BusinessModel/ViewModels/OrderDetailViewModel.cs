

using BirdCageShop.DataAccess.Models;

namespace Ecommerce.BusinessLogic.ViewModels 
{

    public class OrderDetailViewModel {
        public string OrderDetailId { get; set; } = null!;
        public string? OrderId { get; set; }
        public string? ProductId { get; set; }
        public int? Quantity { get; set; }
    }

}
