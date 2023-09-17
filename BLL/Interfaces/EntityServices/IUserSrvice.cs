using AutoRentWebDomain.Entity;
using AutoRentWebDomain.Interfaces;
using AutoRentWebDomain.Response;
using AutoRentWebDomain.ViewModels.CompanyDelegate;
using AutoRentWebDomain.ViewModels.User;
using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces.EntityServices
{
    public interface IUserSrvice:IEntityService<UserDTO>
    {
        Task<BaseResponse<IEnumerable<UserViewModel>>> GetUsers();
        Task<IBaseResponse<bool>> DeleteUser(int id);
        Task<IBaseResponse<bool>> CreateDelegate(CompanyDelegateViewModel model);
    }
}
