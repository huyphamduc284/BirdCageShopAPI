
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
            mc.CreateMap<OrderDetail, OrderDetailViewModel>().ReverseMap()/*.ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product))*/;

            mc.CreateMap<OrderDetail, CreateOrderDetailRequestModel>().ForMember(o => o.Cart, o => o.Ignore()).ReverseMap();
            mc.CreateMap<OrderDetail, UpdateOrderDetailRequestModel>().ReverseMap();
            mc.CreateMap<OrderDetail, CreateCartRequestModel>().ReverseMap()/*
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForAllMembers(opt => opt.Ignore())*/;
        }
    }

}
