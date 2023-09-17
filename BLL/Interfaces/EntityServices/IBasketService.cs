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
    public interface IBasketService:IEntityService<BasketDTO>
    {
        Task<IBaseResponse<IEnumerable<OrderViewModel>>> GetItems(string userName);

        Task<IBaseResponse<OrderViewModel>> GetItem(string userName, int id);
    }
}
