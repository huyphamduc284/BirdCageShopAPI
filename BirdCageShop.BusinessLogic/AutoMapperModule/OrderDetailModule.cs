
using AutoMapper;

using BirdCageShop.DataAccess.Models;
using Ecommerce.BusinessLogic.RequestModels.OrderDetail;
using Ecommerce.BusinessLogic.ViewModels;

namespace BirdCageShop.BusinessLogic.AutoMapperModule 
{

   public static class OrderDetailModule
    {
        public static void ConfigOrderDetailModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<OrderDetail, OrderDetailViewModel>().ReverseMap();
            mc.CreateMap<OrderDetail, CreateOrderDetailRequestModel>().ReverseMap();
            mc.CreateMap<OrderDetail, UpdateOrderDetailRequestModel>().ReverseMap();
        }
    }

}
