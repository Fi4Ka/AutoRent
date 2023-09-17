using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces.EntityServices
{
    public interface IStatisticService
    {
        int GetRentCount(string userName);
        string GetMostRentAuto(string userName);
        decimal GetAllRentCost(string userName);
    }
}
