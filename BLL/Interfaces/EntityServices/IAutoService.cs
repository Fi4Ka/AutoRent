using AutoRentWebDomain.Interfaces;
using AutoRentWebDomain.Response;
using AutoRentWebDomain.ViewModels.Auto;
using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces.EntityServices
{
    public interface IAutoService<T>
    {
        IBaseResponse<IEnumerable<T>> GetAutos();
        IBaseResponse<AutoDTO> GetCar(int id);
        Task<IBaseResponse<T>> Create(AutoViewModel item);
        Task<IBaseResponse<bool>> DeleteCar(int id);
        IBaseResponse<Dictionary<int, string>> GetTypes();
        CompanyDelegateDTO GetCompanyDelegate(string userName);
        TypeCarDTO GetTypeCar(int id);

    }
}
