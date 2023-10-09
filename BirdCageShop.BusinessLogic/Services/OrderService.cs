
using AutoMapper;
using BirdCageShop.BusinessLogic.Enums;
using BirdCageShop.DataAccess.Models;
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
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public OrderViewModel CreateOrder(CreateOrderRequestModel orderCreate)
        {
           var order = _mapper.Map<Order>(orderCreate);
            order.OrderId = Guid.NewGuid().ToString();
            order.UserId = orderCreate.UserId;
            order.OrderDate = DateTime.Now;
            order.OrderStatus = (int?)OrderStatusEnum.Pending;
            order.Address = orderCreate.Address;
            order.State = orderCreate.State;
            order.ZipCode = orderCreate.ZipCode;
            order.Country = orderCreate.Country;
            order.Method = orderCreate.Method;
            order.Rating = orderCreate.Rating;
            order.Comment = orderCreate.Comment;

            _orderRepository.Create(order);
            _orderRepository.Save();

            return _mapper.Map<OrderViewModel>(order);
        }

        public OrderViewModel UpdateOrder(UpdateOrderRequestModel orderUpdate) 
        {
            var order = _orderRepository.Get().SingleOrDefault(x => x.OrderId.Equals(orderUpdate.OrderId));
            if (order == null) return null;
            order.OrderStatus = orderUpdate.OrderStatus;
            _orderRepository.Update(order);
            _orderRepository.Save();

            return _mapper.Map<OrderViewModel>(order);
        }

        public bool DeleteOrder(int idTmp)
        {
            throw new NotImplementedException();
        }

        public List<OrderViewModel> GetAll() 
        {
           var order = _orderRepository.Get().ToList();
            return _mapper.Map<List<OrderViewModel>>(order);
        }

        public OrderViewModel GetById(int idTmp) 
        {
            var order = _orderRepository.Get().SingleOrDefault(x => x.Equals(idTmp));
            return _mapper.Map<OrderViewModel>(order);
        }

    }

}
