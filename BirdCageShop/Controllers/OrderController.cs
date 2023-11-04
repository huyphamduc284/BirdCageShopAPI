

using BirdCageShop.BusinessLogic.Services;
using Ecommerce.BusinessLogic.RequestModels.Order;
using Ecommerce.BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace BirdCageShop.Presentation.Controllers 
{

    [ApiController]
    [ApiVersion("1")]
    [Route("/api/v1/orders")]
    public class OrderController : ControllerBase {

        private IOrderService _orderService;

         public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [MapToApiVersion("1")]
        [HttpPost]
        public ActionResult<OrderViewModel> CreateOrder(CreateOrderRequestModel orderCreate)
        {
            var orderCreated = _orderService.CreateOrder(orderCreate);

            if (orderCreated == null)
            {
                return NotFound("Fail to Create Order");
            }
            return orderCreated;
        }

        [MapToApiVersion("1")]
        [HttpGet]
        public ActionResult<List<OrderViewModel>> GetAll()
        {
            var orderList = _orderService.GetAll();

            if (orderList == null)
            {
                return NotFound("Orders Not Found");
            }
            return orderList;
        }

        [MapToApiVersion("1")]
        [HttpGet("idTmp")]
        public ActionResult<OrderViewModel> GetById(string idTmp)
        {
            var orderDetail = _orderService.GetById(idTmp);

            if (orderDetail == null)
            {
                return NotFound("Order Not Found");
            }
            return orderDetail;
        }
        [MapToApiVersion("1")]
        [HttpGet("userId")]
        public ActionResult<OrderViewModel> GetByUserId(string idTmp)
        {
            var orderDetail = _orderService.GetByUserId(idTmp);

            if (orderDetail == null)
            {
                return NotFound("Order Not Found");
            }
            return orderDetail;
        }

        [MapToApiVersion("1")]
        [HttpDelete]
        public ActionResult<bool> DeleteOrder(string idTmp)
        {
            var check = _orderService.DeleteOrder(idTmp);

            if (check == false)
            {
                return NotFound("Fail To Delete Order");
            }
            return check;
        }

        [MapToApiVersion("1")]
        [HttpPut]
        public ActionResult<OrderViewModel> UpdateOrder(UpdateOrderRequestModel orderCreate)
        {
            var orderUpdated = _orderService.UpdateOrder(orderCreate);

            if (orderUpdated == null)
            {
                return NotFound("Fail To Update Order");
            }
            return orderUpdated;
        }
    }

}
