using AutoMapper;
using AutoRentWeb.DAL.Interfaces;
using AutoRentWebDomain.Entity;
using AutoRentWebDomain.Enum;
using AutoRentWebDomain.Interfaces;
using AutoRentWebDomain.Response;
using AutoRentWebDomain.ViewModels.Auto;
using BLL.DTO;
using BLL.Interfaces.EntityServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AutoService : IAutoService<AutoDTO>
    {
        private readonly IRepository<Auto> autoRepository;
        private readonly IRepository<CompanyDelegate> companyDelegateRepository;
        private readonly IRepository<Company> companyRepository;
        private readonly IRepository<TypeCar> typeCarRepository;
        private readonly IRepository<User> userRepository;
        IMapper mapper;

        public AutoService(IRepository<Auto> autoRepository, IRepository<User> userRepository, IMapper _mapper, IRepository<CompanyDelegate> companyDelegateRepository, IRepository<Company> companyRepository, IRepository<TypeCar> typeCarRepository)
        {
            this.autoRepository = autoRepository;
            mapper = _mapper;
            this.companyDelegateRepository = companyDelegateRepository;
            this.companyRepository = companyRepository;
            this.typeCarRepository= typeCarRepository;
            this.userRepository = userRepository;
        }
        public async Task<IBaseResponse<AutoDTO>> Create(AutoViewModel item)
        {
            try
            {
                var companyDelegate = companyDelegateRepository.GetAll().FirstOrDefault(x => x.Id==item.CompanyDelegateId);
                var typeCar = typeCarRepository.GetAll().FirstOrDefault(x => x.Id == item.TypeCarId);
                var auto = new AutoDTO()
                {
                    Name = item.Name,
                    Year = item.Year,
                    Description = item.Description,
                    CompanyDelegateId = companyDelegate.Id,
                    TypeCarId=typeCar.Id,
                    Price = item.Price,
                    AvatarUrl = item.AvatarUrl
                };
                await autoRepository.Create(mapper.Map<Auto>(auto));

                return new BaseResponse<AutoDTO>()
                {
                    StatusCode = StatusCode.OK,
                    Data = auto
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<AutoDTO>()
                {
                    Description = $"[Create] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
        public IBaseResponse<Dictionary<int, string>> GetTypes()
        {
            try
            {
                var types = typeCarRepository.GetAll().ToDictionary(k=>k.Id,v=>v.Name);

                return new BaseResponse<Dictionary<int, string>>()
                {
                    Data = types,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Dictionary<int, string>>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
        public CompanyDelegateDTO GetCompanyDelegate(string userName)
        {
            try
            {
                var companyDelegate = mapper.Map<CompanyDelegateDTO>(userRepository.GetAll().FirstOrDefault(x => x.Login == userName).CompanyDelegate);
                if (companyDelegate != null)
                    return companyDelegate;
                else
                    throw new Exception();
            }
            catch
            { return null; }
        }

        public async Task<IBaseResponse<bool>> DeleteCar(int id)
        {
            try
            {
                var car = autoRepository.GetAll().FirstOrDefault(x => x.Id == id);
                if (car == null)
                {
                    return new BaseResponse<bool>()
                    {
                        Description = "Car not found",
                        StatusCode = StatusCode.UserNotFound,
                        Data = false
                    };
                }

                await autoRepository.Delete(car);

                return new BaseResponse<bool>()
                {
                    Data = true,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[DeleteCar] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public  IBaseResponse<IEnumerable<AutoDTO>> GetAutos()
        {
            var baseResponse = new BaseResponse<IEnumerable<AutoDTO>>();
            try
            {

                   var autos = mapper.Map<IEnumerable<Auto>, IEnumerable<AutoDTO>>(autoRepository.GetAll()).ToList();
                   if (autos.Count == 0)
                   {
                       baseResponse.Description = "Найдено 0 элементов";
                       baseResponse.StatusCode = AutoRentWebDomain.Enum.StatusCode.AutoNotFound;
                       return baseResponse;
                   }
                baseResponse.Data = autos;
                baseResponse.StatusCode = AutoRentWebDomain.Enum.StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<AutoDTO>>()
                {
                    Description = $"[GetAutos]: {ex.Message}"
                };
            }
        }
        public IBaseResponse<AutoDTO> GetCar(int id)
        {
            try
            {
                var car = mapper.Map<IEnumerable<Auto>, IEnumerable<AutoDTO>>(autoRepository.GetAll()).ToList().FirstOrDefault(x => x.Id == id);
                if (car == null)
                {
                    return new BaseResponse<AutoDTO>()
                    {
                        Description = "Пользователь не найден",
                        StatusCode = StatusCode.AutoNotFound
                    };
                }

               /* var data = new AutoDTO()
                {
                    CompanyDelegateId=car.CompanyDelegateId,
                    Description = car.Description,
                    Name = car.Name,
                    Price = car.Price,
                    TypeCarId = car.TypeCar.Id,
                    AvatarUrl = car.AvatarUrl,
                    Year = car.Year,
                };*/

                return new BaseResponse<AutoDTO>()
                {
                    StatusCode = StatusCode.OK,
                    Data = car
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<AutoDTO>()
                {
                    Description = $"[GetCar] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public TypeCarDTO GetTypeCar(int id)
        {
           try
            {
                var type=mapper.Map<TypeCarDTO>(typeCarRepository.GetAll().FirstOrDefault(x=>x.Id == id));
                return type;
            }
            catch
            {
                return null;
            }
        }
    }
}
