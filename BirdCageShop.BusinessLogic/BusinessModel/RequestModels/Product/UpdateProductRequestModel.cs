

namespace Ecommerce.BusinessLogic.RequestModels.Product 
{

   public class UpdateProductRequestModel {
        public string ProductId { get; set; } = null!;
        public string? ProductName { get; set; }
        public string? BirdType { get; set; }
        public string? Model { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }
        public int? Status { get; set; }
        public int? Size { get; set; }
        public string? ProductMaterial { get; set; }
        public string? BirdCageType { get; set; }
        public string? Image { get; set; }
    }

}
