
using BirdCageShop.DataAccess.Repositories;
using Ecommerce.BusinessLogic.RequestModels.Order;
using Ecommerce.BusinessLogic.ViewModels;

namespace BirdCageShop.BusinessLogic.Services 
{

    public interface IOrderService {
        public OrderViewModel CreateOrder(CreateOrderRequestModel orderCreate);
        public OrderViewModel UpdateOrder(UpdateOrderRequestModel orderUpdate);
        public bool DeleteOrder(int idTmp);
        public List<OrderViewModel> GetAll();
        public OrderViewModel GetById(int idTmp);
    }

    public class OrderService : IOrderService {

      private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public OrderViewModel CreateOrder(CreateOrderRequestModel orderCreate)
        {
            throw new NotImplementedException();
        }

        public OrderViewModel UpdateOrder(UpdateOrderRequestModel orderUpdate) 
        {
            throw new NotImplementedException();
        }

        public bool DeleteOrder(int idTmp)
        {
            throw new NotImplementedException();
        }

        public List<OrderViewModel> GetAll() 
        {
            throw new NotImplementedException();
        }

        public OrderViewModel GetById(int idTmp) 
        {
            throw new NotImplementedException();
        }

    }

}
