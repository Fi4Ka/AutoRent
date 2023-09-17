using AutoMapper;
using AutoRentWeb.DAL.Interfaces;
using AutoRentWeb.DAL.Repositories;
using AutoRentWebDomain.Entity;
using AutoRentWebDomain.Enum;
using AutoRentWebDomain.EnumExtension;
using AutoRentWebDomain.Helper;
using AutoRentWebDomain.Response;
using AutoRentWebDomain.ViewModels.Account;
using BLL.DTO;
using BLL.Interfaces.EntityServices;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AccountService : IAccountService
    {
        private readonly IRepository<User> userRepository;
        private readonly IRepository<Arendator> arendatorRepository;
        private readonly IRepository<Basket> basketRepository;
        private readonly IMapper mapper;
        public AccountService(IRepository<Arendator> arendatorRepository, IRepository<Basket> basketRepository,IRepository<User> userRepository,IMapper mapper)
        {
            this.arendatorRepository = arendatorRepository;

            this.basketRepository = basketRepository;
            this.userRepository = userRepository;
            this.mapper = mapper;

        }
        public async Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModal model)
        {
            try
            {
                /*var rrr = new UserDTO()
                {
                    Login = "Belaziki",
                    Password = HashPasswordHelper.HashPassowrd("888"),
                    Role = Role.Delegate.GetDisplayName(),
                };
                var www = mapper.Map<User>(rrr);
                await userRepository.Create(www);*/
                var user = mapper.Map<UserDTO>(userRepository.GetAll().FirstOrDefault(x => x.Login == model.Name));
                if (user == null)
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Description = "Пользователь не найден"
                    };
                }

                if (user.Password != HashPasswordHelper.HashPassowrd(model.Password))
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Description = "Неверный пароль или логин"
                    };
                }
                var result = Authenticate(user);

                return new BaseResponse<ClaimsIdentity>()
                {
                    Data = result,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<BaseResponse<ClaimsIdentity>> Register(RegisterViewModel model)
        {
            try
            {
               
                var user =  mapper.Map<UserDTO>(userRepository.GetAll().FirstOrDefault(x => x.Login == model.Name));
                if (user != null)
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Description = "Пользователь с таким логином уже есть",
                    };
                }
                user = new UserDTO()
                {
                    Login = model.Name,
                    Role = Role.User.GetDisplayName(),
                    Password = HashPasswordHelper.HashPassowrd(model.Password),
                };
                var x = mapper.Map<User>(user);
                var y = x.Role.GetDisplayName();
                await userRepository.Create(x);

                var client = new ArendatorDTO()
                {
                    Adress = model.Adress,
                    Name= model.ClientName,
                    PhoneNumber= model.PhoneNumber,
                    UserId = userRepository.GetAll().Last().Id,
                };


                await arendatorRepository.Create(mapper.Map<Arendator>(client));
                var basket = new BasketDTO()
                {
                    ArendatorId = arendatorRepository.GetAll().Last().Id,
                };
                await basketRepository.Create(mapper.Map<Basket>(basket));
                var result = Authenticate(user);

                return new BaseResponse<ClaimsIdentity>()
                {
                    Data = result,
                    Description = "Объект добавился",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<BaseResponse<bool>> ChangePassword(ChangePasswordViewModel model)
        {
            try
            {
                var user =  userRepository.GetAll().FirstOrDefault(x => x.Login == model.UserName);
                if (user == null)
                {
                    return new BaseResponse<bool>()
                    {
                        StatusCode = StatusCode.UserNotFound,
                        Description = "Пользователь не найден"
                    };
                }

                user.Password = HashPasswordHelper.HashPassowrd(model.NewPassword);
                await userRepository.Update(user);

                return new BaseResponse<bool>()
                {
                    Data = true,
                    StatusCode = StatusCode.OK,
                    Description = "Пароль обновлен"
                };

            }
            catch (Exception ex)
            {
                
                return new BaseResponse<bool>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        private ClaimsIdentity Authenticate(UserDTO user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString())
            };
            return new ClaimsIdentity(claims, "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }
    }
}
