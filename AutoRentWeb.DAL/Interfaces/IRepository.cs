using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRentWeb.DAL.Interfaces
{
    public interface IRepository<TEntity>
    {
        Task Create(TEntity entity);

        IEnumerable<TEntity> GetAll();

        Task Delete(TEntity entity);

        Task<TEntity> Update(TEntity entity);
    }
}
