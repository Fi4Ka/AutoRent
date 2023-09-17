using AutoMapper;
using AutoRentWebDomain.EnumExtension;
using AutoRentWebDomain.Entity;
using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using AutoRentWebDomain.Enum;
using System.Net.Http.Headers;

namespace BLL.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile() 
        {
            CreateMap<User, UserDTO>().ForMember(det=>det.Role,opt=>opt.MapFrom(src=>src.Role.GetDisplayName()));
            CreateMap<UserDTO, User>().ForMember(det => det.Role, opt => opt.MapFrom(src=>new Role().GetByDisplayName(src.Role)));
        }
    }
}
