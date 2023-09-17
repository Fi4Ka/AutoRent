using AutoRentWebDomain.ViewModels.Auto;
using BLL.DTO;
using BLL.Interfaces;

namespace AutoRentWeb.Mappers
{
    public static class AutoMapper
    {
        public static AutoViewModel FromDto(IModel model)
        {
            var dto = model as AutoDTO;
            return new AutoViewModel()
            {
                Id = dto!.Id,
                AvatarUrl = dto!.AvatarUrl,
                Description = dto!.Description,
                CompanyDelegateId = dto!.CompanyDelegateId,
                CompanyDelegateName=dto!.CompanyDelegate.Name,
                Company=dto!.CompanyDelegate!.Company.Name,
                CompanyDelegatePhone= dto!.CompanyDelegate.PhoneNumber,
                Name = dto!.Name,
                CompanyId=dto!.CompanyDelegate!.CompanyId,
                Price = dto!.Price,
                TypeCar=dto!.TypeCar.Name,
                Year=dto!.Year,
                TypeCarId=dto!.TypeCar.Id,
            };
        }

        public static AutoDTO ToDto(AutoViewModel entity)
        {

            return new AutoDTO()
            {
                Id = entity.Id,
                Description = entity.Description,
                CompanyDelegateId= entity.CompanyDelegateId,
                TypeCarId=entity.TypeCarId,
                AvatarUrl=entity.AvatarUrl,
                Name=entity.Name,
                Price=entity.Price,
                Year = entity.Year,
            };
        }
    }
}
