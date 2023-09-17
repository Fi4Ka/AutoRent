using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces.EntityServices
{
    internal interface ICompanyDelegateService:IEntityService<CompanyDelegateDTO>
    {
        void Create(CompanyDelegateDTO item);
        void Delete(int id);
    }
}
