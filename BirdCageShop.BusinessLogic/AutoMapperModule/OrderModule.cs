
using AutoMapper;
using BirdCageShop.DataAccess.Models;
using Ecommerce.BusinessLogic.RequestModels.Order;
using Ecommerce.BusinessLogic.ViewModels;

namespace BirdCageShop.BusinessLogic.AutoMapperModule 
{

   public static class OrderModule
    {
        public static void ConfigOrderModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Order, OrderViewModel>().ReverseMap();
            mc.CreateMap<Order, CreateOrderRequestModel>().ReverseMap();
            mc.CreateMap<Order, UpdateOrderRequestModel>().ReverseMap();
            mc.CreateMap<Order, UpdateOrderByIdRequestModel>().ReverseMap();
            mc.CreateMap<Order, AssignEmpRequestModel   >().ReverseMap();


        }
    }

}
