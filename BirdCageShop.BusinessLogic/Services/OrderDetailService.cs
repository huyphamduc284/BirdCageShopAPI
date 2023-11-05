
using AutoMapper;
using BirdCageShop.DataAccess.Models;
using BirdCageShop.DataAccess.Repositories;
using Ecommerce.BusinessLogic.RequestModels.OrderDetail;
using Ecommerce.BusinessLogic.ViewModels;

namespace BirdCageShop.BusinessLogic.Services 
{

    public interface IOrderDetailService {
        public OrderDetailViewModel CreateOrderDetail(CreateOrderDetailRequestModel orderdetailCreate);
        public OrderDetailViewModel UpdateOrderDetail(UpdateOrderDetailRequestModel orderdetailUpdate);
        public bool DeleteOrderDetail(string idTmp);
        public bool DeleteByOrderId(string idTmp);

        public List<OrderDetailViewModel> GetAll();
        public OrderDetailViewModel GetById(string idTmp);
    }

    public class OrderDetailService : IOrderDetailService {

      private readonly IOrderDetailRepository _orderdetailRepository;
        private readonly IMapper _mapper;

        public OrderDetailService(IOrderDetailRepository orderdetailRepository, IMapper mapper)
        {
            _orderdetailRepository = orderdetailRepository;
            _mapper = mapper;
        }

        public OrderDetailViewModel CreateOrderDetail(CreateOrderDetailRequestModel orderdetailCreate)
        {
            var orderDetail = _mapper.Map<OrderDetail>(orderdetailCreate);
            orderDetail.OrderDetailId = Guid.NewGuid().ToString();

            _orderdetailRepository.Create(orderDetail);
            _orderdetailRepository.Save();

            return _mapper.Map<OrderDetailViewModel>(orderDetail);

        }

        public OrderDetailViewModel UpdateOrderDetail(UpdateOrderDetailRequestModel orderdetailUpdate) 
        {
            var orderDetail = _orderdetailRepository.Get().SingleOrDefault(x => x.OrderDetailId.Equals(orderdetailUpdate.OrderDetailId));
            if (orderDetail == null) return null;
            orderDetail.Quantity = orderdetailUpdate.Quantity;

            _orderdetailRepository.Update(orderDetail);
            _orderdetailRepository.Save();

            return _mapper.Map<OrderDetailViewModel>(orderDetail);
        }

        public bool DeleteOrderDetail(String idTmp)
        {
            var orderDetail = _orderdetailRepository.Get().SingleOrDefault(x => x.OrderDetailId.Equals(idTmp));
            if(orderDetail == null) return false;
            _orderdetailRepository.Delete(orderDetail);
            _orderdetailRepository.Save();
            return true;
        }

        public List<OrderDetailViewModel> GetAll() 
        {
           var orderDetails = _orderdetailRepository.Get().ToList();
            return _mapper.Map<List<OrderDetailViewModel>>(orderDetails);
        }

        public OrderDetailViewModel GetById(string idTmp) 
        {
            var orderDetail = _orderdetailRepository.Get().SingleOrDefault(x => x.OrderDetailId.Equals(idTmp));
            return _mapper.Map<OrderDetailViewModel>(orderDetail);
        }

        public bool DeleteByOrderId(string idTmp)
        {
            var orderDetail = _orderdetailRepository.Get().SingleOrDefault(x => x.OrderId.Equals(idTmp));
            if (orderDetail == null) return false;
            _orderdetailRepository.Delete(orderDetail);
            _orderdetailRepository.Save();
            return true;
        }
    }

}
