using AutoMapper;
using AutoRentWeb.DAL.Interfaces;
using AutoRentWebDomain.Entity;
using AutoRentWebDomain.Enum;
using AutoRentWebDomain.Response;
using AutoRentWebDomain.ViewModels.Arendator;
using BLL.DTO;
using BLL.Interfaces.EntityServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ArendatorService : IArendatorService
    {
        private readonly IRepository<Arendator> arendatorRepository;
        private readonly IMapper mapper;
        private readonly IRepository<User> userRepository;
        public ArendatorService(IRepository<Arendator> arendatorRepository, IRepository<User> userRepository, IMapper mapper)
        {
            this.arendatorRepository = arendatorRepository;
            this.userRepository = userRepository;
            this.mapper = mapper;

        }
        public IEnumerable<ArendatorDTO> Get()
        {
            return mapper.Map<IEnumerable<ArendatorDTO>>(arendatorRepository.GetAll());
        }

        public async Task<BaseResponse<ProfileViewModal>> GetProfile(string userName)
        {
            try
            {
                var profile = mapper.Map<IEnumerable<ArendatorDTO>>(arendatorRepository.GetAll())
                    .Select(x => new ProfileViewModal()
                    {
                        Id = x.Id,
                        Adress = x.Adress,
                        Name = x.Name,
                        PhoneNumber = x.PhoneNumber,
                        UserName=x.User.Login
                    })
                    .FirstOrDefault(x => x.UserName == userName);

                return new BaseResponse<ProfileViewModal>()
                {
                    Data = profile,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<ProfileViewModal>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }

        public async Task<BaseResponse<ArendatorDTO>> Update(ProfileViewModal model)
        {
            try
            {
                var profile = arendatorRepository.GetAll()
                    .FirstOrDefault(x => x.Id == model.Id);

                profile.Adress = model.Adress;
                profile.PhoneNumber = model.PhoneNumber;
                profile.Name= model.Name;

                await arendatorRepository.Update(profile);

                return new BaseResponse<ArendatorDTO>()
                {
                    Data = mapper.Map<ArendatorDTO>(profile),
                    Description = "Данные обновлены",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<ArendatorDTO>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }
    }
}
