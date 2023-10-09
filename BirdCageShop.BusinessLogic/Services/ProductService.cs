

using AutoMapper;
using BirdCageShop.DataAccess.Repositories;
using Ecommerce.BusinessLogic.RequestModels.Product;
using Ecommerce.BusinessLogic.ViewModels;

namespace BirdCageShop.BusinessLogic.Services 
{

    public interface IProductService {
        public ProductViewModel CreateProduct(CreateProductRequestModel productCreate);
        public ProductViewModel UpdateProduct(UpdateProductRequestModel productUpdate);
        public bool DeleteProduct(int idTmp);
        public List<ProductViewModel> GetAll();
        public ProductViewModel GetById(int idTmp);
    }

    public class ProductService : IProductService {

      private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper )
        {
            _productRepository = productRepository;
            _mapper = mapper;

        }

        public ProductViewModel CreateProduct(CreateProductRequestModel productCreate)
        {
            throw new NotImplementedException();

        }

        public ProductViewModel UpdateProduct(UpdateProductRequestModel productUpdate) 
        {
            throw new NotImplementedException();
        }

        public bool DeleteProduct(int idTmp)
        {
            throw new NotImplementedException();
        }

        public List<ProductViewModel> GetAll() 
        {
            throw new NotImplementedException();
        }

        public ProductViewModel GetById(int idTmp) 
        {
            throw new NotImplementedException();
        }

    }

}
