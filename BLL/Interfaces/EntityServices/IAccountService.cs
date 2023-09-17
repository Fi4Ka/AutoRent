using AutoRentWebDomain.Response;
using AutoRentWebDomain.ViewModels.Account;
using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces.EntityServices
{
    public interface IAccountService
    {
        Task<BaseResponse<ClaimsIdentity>> Register(RegisterViewModel model);

        Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModal model);

        Task<BaseResponse<bool>> ChangePassword(ChangePasswordViewModel model);

    }
}
