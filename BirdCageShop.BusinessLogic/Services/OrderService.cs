
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
        public OrderViewModel CreateOrder(CreateOrderRequestModel orderCreate/*, List<CreateOrderDetailRequestModel> orderDetails*/);
        public OrderViewModel UpdateOrder(UpdateOrderRequestModel orderUpdate);
        public OrderViewModel UpdateOrderById(UpdateOrderByIdRequestModel orderStatusUpdate);
        public OrderViewModel AssignEmployee(AssignEmpRequestModel assignEmpRequest);
        

        public bool DeleteOrder(string idTmp);
        public List<OrderViewModel> GetAll();
        public OrderViewModel GetById(string idTmp);
        public OrderViewModel GetByUserId(string userId);
        public List<OrderViewModel> GetOrderByEmpId(string empId);

    }

    public class OrderService : IOrderService {

        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper, IUserService userService, IOrderDetailService orderDetailService)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _userService = userService;
            _orderDetailService = orderDetailService;
        }

        public OrderViewModel CreateOrder(CreateOrderRequestModel orderCreate)
        {
            var order = _mapper.Map<Order>(orderCreate);
            var processingTimeInDay = 3;
            var expectedDeliveryDate = DateTime.Now;

            order.OrderId = Guid.NewGuid().ToString();
            order.OrderDate = DateTime.Now;        
            order.OrderStatus = (int?)OrderStatusEnum.Pending;
            order.ExpectedDeliveryDate = expectedDeliveryDate;

            _orderRepository.Create(order);
            _orderRepository.Save();

            foreach (var product in orderCreate.orderDetail)
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

            if(orderUpdate.OrderStatus == (int)OrderStatusEnum.Cancelled)
            {
                _orderDetailService.DeleteByOrderId(orderUpdate.OrderId);
            }

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

        public OrderViewModel UpdateOrderById(UpdateOrderByIdRequestModel orderStatusUpdate)
        {
            var order = _orderRepository.Get().SingleOrDefault(x => x.OrderId.Equals(orderStatusUpdate.OrderId));
            if (orderStatusUpdate.OrderStatus.Equals("Pending")){
                order.OrderStatus = (int?)OrderStatusEnum.Pending;
            }else if (orderStatusUpdate.OrderStatus.Equals("Processing")){
                order.OrderStatus = (int?)OrderStatusEnum.Processing;
            }
            else if (orderStatusUpdate.OrderStatus.Equals("Shipped")){
                order.OrderStatus = (int?)OrderStatusEnum.Shipped;
            }
            else if (orderStatusUpdate.OrderStatus.Equals("Delivered")){
                order.OrderStatus = (int?)OrderStatusEnum.Delivered;
            }
            else if (orderStatusUpdate.OrderStatus.Equals("Cancelled")){
                order.OrderStatus = (int?)OrderStatusEnum.Cancelled;
            }
            _orderRepository.Update(order);
            _orderRepository.Save();

            return _mapper.Map<OrderViewModel>(order);
        }

        public OrderViewModel AssignEmployee(AssignEmpRequestModel assignEmpRequest)
        {
            var order = _orderRepository.Get().SingleOrDefault(x => x.OrderId.Equals(assignEmpRequest.OrderId));
            if (order == null) return null;
         
            order.AssignedEmp = assignEmpRequest.UserId;

            _orderRepository.Update(order);
            _orderRepository.Save();

            return _mapper.Map<OrderViewModel>(order);
        }

        public List<OrderViewModel> GetOrderByEmpId(string empId)
        {
            var order = _orderRepository.Get().Where(x => x.AssignedEmp.Equals(empId)).ToList();
            if (order == null) return null;

            return _mapper.Map<List<OrderViewModel>>(order);
        }
    }

}
