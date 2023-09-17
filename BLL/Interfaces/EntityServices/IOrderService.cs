using AutoRentWebDomain.Entity;
using AutoRentWebDomain.Interfaces;
using AutoRentWebDomain.ViewModels.Order;
using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces.EntityServices
{
    public interface IOrderService:IEntityService<OrderDTO>
    {
        Task<IBaseResponse<OrderDTO>> Create(CreateOrderViewModel model);
    }
}
