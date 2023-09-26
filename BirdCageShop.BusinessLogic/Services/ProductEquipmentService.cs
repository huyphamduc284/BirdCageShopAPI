
using BirdCageShop.DataAccess.Repositories;
using Ecommerce.BusinessLogic.RequestModels.ProductEquipment;
using Ecommerce.BusinessLogic.ViewModels;

namespace BirdCageShop.BusinessLogic.Services 
{

    public interface IProductEquipmentService {
        public ProductEquipmentViewModel CreateProductEquipment(CreateProductEquipmentRequestModel productequipmentCreate);
        public ProductEquipmentViewModel UpdateProductEquipment(UpdateProductEquipmentRequestModel productequipmentUpdate);
        public bool DeleteProductEquipment(int idTmp);
        public List<ProductEquipmentViewModel> GetAll();
        public ProductEquipmentViewModel GetById(int idTmp);
    }

    public class ProductEquipmentService : IProductEquipmentService {

      private readonly IProductEquipmentRepository _productequipmentRepository;

        public ProductEquipmentService(IProductEquipmentRepository productequipmentRepository)
        {
            _productequipmentRepository = productequipmentRepository;
        }

        public ProductEquipmentViewModel CreateProductEquipment(CreateProductEquipmentRequestModel productequipmentCreate)
        {
            throw new NotImplementedException();
        }

        public ProductEquipmentViewModel UpdateProductEquipment(UpdateProductEquipmentRequestModel productequipmentUpdate) 
        {
            throw new NotImplementedException();
        }

        public bool DeleteProductEquipment(int idTmp)
        {
            throw new NotImplementedException();
        }

        public List<ProductEquipmentViewModel> GetAll() 
        {
            throw new NotImplementedException();
        }

        public ProductEquipmentViewModel GetById(int idTmp) 
        {
            throw new NotImplementedException();
        }

    }

}
