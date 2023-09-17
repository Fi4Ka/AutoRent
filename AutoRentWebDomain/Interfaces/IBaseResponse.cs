using AutoRentWebDomain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRentWebDomain.Interfaces
{
    public interface IBaseResponse<T>
    {
        T Data { get; set; }
        public string Description { get; set; }
        public StatusCode StatusCode { get; set; }
    }
}
