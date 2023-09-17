using AutoMapper;
using AutoRentWebDomain.Response;
using AutoRentWebDomain.ViewModels.Arendator;
using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces.EntityServices
{
    public interface IArendatorService:IEntityService<ArendatorDTO>
    {
        Task<BaseResponse<ProfileViewModal>> GetProfile(string userName);

        Task<BaseResponse<ArendatorDTO>> Update(ProfileViewModal model);
    }
}
