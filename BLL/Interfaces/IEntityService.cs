using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IEntityService<T> where T : class
    {
        IEnumerable<T> Get();
    }
}
