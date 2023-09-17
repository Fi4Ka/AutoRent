﻿using AutoMapper;
using AutoRentWebDomain.Entity;
using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Profiles
{
    public class BasketProfile:Profile
    {
        public BasketProfile() 
        {
            CreateMap<Basket, BasketDTO>().ReverseMap();
        }
    }
}
