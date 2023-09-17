using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRentWebDomain.Enum
{
    public enum StatusCode
    {
        UserNotFound = 0,
        AutoNotFound = 10,
        OK =200,
        InternalServerError=500,
        OrderNotFound = 20,
    }
}
