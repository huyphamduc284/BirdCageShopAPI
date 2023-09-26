
using BirdCageShop.DataAccess.Repositories;
using Ecommerce.BusinessLogic.RequestModels.OrderDetail;
using Ecommerce.BusinessLogic.ViewModels;

namespace BirdCageShop.BusinessLogic.Services 
{

    public interface IOrderDetailService {
        public OrderDetailViewModel CreateOrderDetail(CreateOrderDetailRequestModel orderdetailCreate);
        public OrderDetailViewModel UpdateOrderDetail(UpdateOrderDetailRequestModel orderdetailUpdate);
        public bool DeleteOrderDetail(int idTmp);
        public List<OrderDetailViewModel> GetAll();
        public OrderDetailViewModel GetById(int idTmp);
    }

    public class OrderDetailService : IOrderDetailService {

      private readonly IOrderDetailRepository _orderdetailRepository;

        public OrderDetailService(IOrderDetailRepository orderdetailRepository)
        {
            _orderdetailRepository = orderdetailRepository;
        }

        public OrderDetailViewModel CreateOrderDetail(CreateOrderDetailRequestModel orderdetailCreate)
        {
            throw new NotImplementedException();
        }

        public OrderDetailViewModel UpdateOrderDetail(UpdateOrderDetailRequestModel orderdetailUpdate) 
        {
            throw new NotImplementedException();
        }

        public bool DeleteOrderDetail(int idTmp)
        {
            throw new NotImplementedException();
        }

        public List<OrderDetailViewModel> GetAll() 
        {
            throw new NotImplementedException();
        }

        public OrderDetailViewModel GetById(int idTmp) 
        {
            throw new NotImplementedException();
        }

    }

}
