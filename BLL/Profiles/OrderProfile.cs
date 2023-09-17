using AutoMapper;
using AutoRentWebDomain.Entity;
using AutoRentWebDomain.EnumExtension;
using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Profiles
{
    public class OrderProfile:Profile
    {
        public OrderProfile() 
        {
            CreateMap<Order, OrderDTO>().ForMember(dest=>dest.StatusOrder,opt=>opt.MapFrom(src=>src.StatusOrder.GetDisplayName()));
            CreateMap<OrderDTO, Order>().ForMember(dest => dest.StatusOrder, opt => opt.MapFrom(src => src.StatusOrderEn));
        }
    }
}
