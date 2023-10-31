

namespace Ecommerce.BusinessLogic.RequestModels.Product 
{

   public class CreateProductRequestModel {
      
        public string? ProductName { get; set; }
        public string? BirdType { get; set; }
        public string? Model { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }
        public int? Status { get; set; }
        public int? Size { get; set; }
        public string? ProductMaterial { get; set; }
        public int? BirdCageType { get; set; }
        public string? Image { get; set; }
        public int? Rating { get; set; }

    }

}
