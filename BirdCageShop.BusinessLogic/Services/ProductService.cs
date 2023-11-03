

using AutoMapper;
using BirdCageShop.BusinessLogic.Enums;
using BirdCageShop.DataAccess.Models;
using BirdCageShop.DataAccess.Repositories;
using Ecommerce.BusinessLogic.RequestModels.Product;
using Ecommerce.BusinessLogic.ViewModels;

namespace BirdCageShop.BusinessLogic.Services 
{

    public interface IProductService {
        public ProductViewModel CreateProduct(CreateProductRequestModel productCreate);
        public ProductViewModel UpdateProduct(UpdateProductRequestModel productUpdate);
        public bool DeleteProduct(string idTmp);
        public List<ProductViewModel> GetAll();
        public ProductViewModel GetById(string idTmp);
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
            var product = _mapper.Map<Product>(productCreate);
            product.ProductId = Guid.NewGuid().ToString();
            product.Status = (int?)ProductStatusEnum.availible;

            _productRepository.Create(product);
            _productRepository.Save();

            return _mapper.Map<ProductViewModel>(product);


        }

        public ProductViewModel UpdateProduct(UpdateProductRequestModel productUpdate) 
        {
            var product = _productRepository.Get().SingleOrDefault(x => x.ProductId.Equals(productUpdate.ProductId));
            if (product == null) return null;
            product.ProductName = productUpdate.ProductName;
            product.BirdType = productUpdate.BirdType;
            product.Model = productUpdate.Model;
            product.Price = productUpdate.Price;
            product.Description = productUpdate.Description;
            product.Status = productUpdate.Status;
            product.Size = productUpdate.Size;
            product.Quantity = productUpdate.Quantity;
            product.ProductMaterial = productUpdate.ProductMaterial;
            product.BirdCageType = productUpdate.BirdCageType;
            product.Image = productUpdate.Image;
            product.Rating = productUpdate.Rating;

            _productRepository.Update(product);
            _productRepository.Save();

            return _mapper.Map<ProductViewModel>(product);

        }

        public bool DeleteProduct(string idTmp)
        {
            var product = _productRepository.Get().SingleOrDefault(x => x.ProductId.Equals(idTmp));
            if (product == null) return false;
            product.Status = (int?)ProductStatusEnum.unavailible;

            _productRepository.Update(product);
            _productRepository.Save();

            return true;
        }

        public List<ProductViewModel> GetAll() 
        {
            var products = _productRepository.Get().ToList();
            return _mapper.Map<List<ProductViewModel>>(products);
        }

        public ProductViewModel GetById(string idTmp) 
        {
            var product = _productRepository.Get().SingleOrDefault(x => x.ProductId.Equals(idTmp));
            if (product == null) return null;

            return _mapper.Map<ProductViewModel>(product);
        }

    }

}
