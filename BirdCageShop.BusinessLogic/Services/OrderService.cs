
using AutoMapper;
using BirdCageShop.BusinessLogic.Enums;
using BirdCageShop.DataAccess.Models;
using BirdCageShop.DataAccess.Repositories;
using Ecommerce.BusinessLogic.RequestModels.Order;
using Ecommerce.BusinessLogic.RequestModels.OrderDetail;
using Ecommerce.BusinessLogic.RequestModels.Product;
using Ecommerce.BusinessLogic.ViewModels;

namespace BirdCageShop.BusinessLogic.Services 
{

    public interface IOrderService {
        public OrderViewModel CreateOrder(CreateOrderRequestModel orderCreate, List<CreateOrderDetailRequestModel> orderDetails);
        public OrderViewModel UpdateOrder(UpdateOrderRequestModel orderUpdate);
        public bool DeleteOrder(string idTmp);
        public List<OrderViewModel> GetAll();
        public OrderViewModel GetById(string idTmp);
        public OrderViewModel GetByUserId(string userId);
    }

    public class OrderService : IOrderService {

        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public OrderViewModel CreateOrder(CreateOrderRequestModel orderCreate, List<CreateOrderDetailRequestModel> orderDetails)
        {
            var order = _mapper.Map<Order>(orderCreate);
            var processingTimeInDay = 3;
            var expectedDeliveryDate = order.OrderDate.Value.AddDays(processingTimeInDay);

            order.OrderId = Guid.NewGuid().ToString();          
            order.OrderDate = DateTime.Now;        
            order.OrderStatus = (int?)OrderStatusEnum.Pending;

            order.ExpectedDeliveryDate = expectedDeliveryDate;

            _orderRepository.Create(order);
            _orderRepository.Save();
            foreach (var product in orderDetails)
            {
                var orderDetail = _mapper.Map<OrderDetail>(product);

                _orderDetailRepository.Create(orderDetail);
                _orderDetailRepository.Save();
            }

            return _mapper.Map<OrderViewModel>(order);
        }

        public OrderViewModel UpdateOrder(UpdateOrderRequestModel orderUpdate) 
        {
            var order = _orderRepository.Get().SingleOrDefault(x => x.OrderId.Equals(orderUpdate.OrderId));
            if (order == null) return null;
            order.OrderStatus = orderUpdate.OrderStatus;
            order.UserId = orderUpdate.UserId;
            order.Address = orderUpdate.Address;
            order.State = orderUpdate.State;
            order.ZipCode = orderUpdate.ZipCode;
            order.Country = orderUpdate.Country;
            order.Method = orderUpdate.Method;
            order.Comment = orderUpdate.Comment;

            _orderRepository.Update(order);
            _orderRepository.Save();

            return _mapper.Map<OrderViewModel>(order);
        }

        public bool DeleteOrder(string idTmp)
        {
            var order = _orderRepository.Get().SingleOrDefault(x => x.OrderId.Equals(idTmp));
            if (order == null) return false;
            order.OrderStatus = (int?)OrderStatusEnum.Cancelled;

            _orderRepository.Update(order);
            _orderRepository.Save();

            return true;
        }

        public List<OrderViewModel> GetAll() 
        {
           var orders = _orderRepository.Get().ToList();
            return _mapper.Map<List<OrderViewModel>>(orders);
        }

        public OrderViewModel GetById(string idTmp) 
        {
            var order = _orderRepository.Get().SingleOrDefault(x => x.Equals(idTmp));
            if (order == null) return null;
            return _mapper.Map<OrderViewModel>(order);
        }

        public OrderViewModel GetByUserId(string userId)
        {
            var order = _orderRepository.Get().SingleOrDefault(x => x.UserId.Equals(userId));
            if (order == null) return null;

            return _mapper.Map<OrderViewModel>(order);
        }
    }

}
