using AutoMapper;
using AutoRentWeb.DAL.Interfaces;
using AutoRentWeb.DAL.Repositories;
using AutoRentWebDomain.Entity;
using AutoRentWebDomain.Enum;
using AutoRentWebDomain.EnumExtension;
using AutoRentWebDomain.Interfaces;
using AutoRentWebDomain.Response;
using AutoRentWebDomain.ViewModels.CompanyDelegate;
using AutoRentWebDomain.ViewModels.User;
using BLL.DTO;
using BLL.Interfaces.EntityServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IUserSrvice
    {
        private readonly IRepository<User> userRepository;
        private readonly IRepository<Company> companyRepository;
        private readonly IRepository<CompanyDelegate> companyDelegateRepository;
        private readonly IMapper mapper;
        public UserService(IRepository<User> userRepository, IRepository<Company> companyRepository, IRepository<CompanyDelegate> companyDelegateRepository,IMapper mapper)
        {
            this.userRepository = userRepository;
            this.companyRepository = companyRepository;
            this.companyDelegateRepository = companyDelegateRepository;
            this.mapper=mapper;
        }

        public async Task<IBaseResponse<bool>> CreateDelegate(CompanyDelegateViewModel model)
        {
            try
            {
                var company = new CompanyDTO()
                {
                    Name = model.CompanyName,
                };
                await companyRepository.Create(mapper.Map<Company>(company));
                var user = new UserDTO()
                {
                    Login = model.Login,
                    Password = AutoRentWebDomain.Helper.HashPasswordHelper.HashPassowrd(model.Password),
                    Role = model.Role.GetDisplayName(),
                };
                await userRepository.Create(mapper.Map<User>(user));
                var companyDelegate = new CompanyDelegateDTO()
                {
                    CompanyId = companyRepository.GetAll().Last().Id,
                    UserId = userRepository.GetAll().Last().Id,
                    Name = model.Name,
                    PhoneNumber = model.PhoneNumber
                };
                await companyDelegateRepository.Create(mapper.Map<CompanyDelegate>(companyDelegate));
                return new BaseResponse<bool>()
                {
                    StatusCode = StatusCode.OK,
                    Description = $"Представитель компании создан"
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }

        public async Task<IBaseResponse<bool>> DeleteUser(int id)
        { 
            try
            {
                var user =  userRepository.GetAll().FirstOrDefault(x => x.Id == id);
                if (user == null)
                {
                    return new BaseResponse<bool>
                    {
                        StatusCode = StatusCode.UserNotFound,
                        Data = false
                    };
                }
                await userRepository.Delete(user);

                return new BaseResponse<bool>
                {
                    StatusCode = StatusCode.OK,
                    Data = true
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }

        public IEnumerable<UserDTO> Get()
        {
            return mapper.Map<IEnumerable<UserDTO>>(userRepository.GetAll());
        }

        public async Task<BaseResponse<IEnumerable<UserViewModel>>> GetUsers()
        {
            try
            {
                var users =  userRepository.GetAll()
                    .Where(x=>x.Role!=Role.Admin)
                    .Select(x => new UserViewModel()
                    {
                        Id = x.Id,
                        Name = x.Login,
                        Role = x.Role.GetDisplayName(),
                    })
                    .ToList();

                return new BaseResponse<IEnumerable<UserViewModel>>()
                {
                    Data = users,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<UserViewModel>>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }
    }
}
