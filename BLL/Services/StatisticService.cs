using AutoMapper;
using AutoRentWeb.DAL.Interfaces;
using AutoRentWebDomain.Entity;
using BLL.DTO;
using BLL.Interfaces.EntityServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class StatisticService : IStatisticService
    {
        private readonly IRepository<Auto> autoRepository;
        private readonly IRepository<Order> orderRepository;
        private readonly IRepository<User> userRepository;
        private readonly IMapper mapper;

        public StatisticService(IMapper mapper,IRepository<Auto> autoRepository,IRepository<Order> orderRepository,IRepository<User> userRepository)
        {
            this.mapper = mapper;
            this.autoRepository = autoRepository;
            this.orderRepository = orderRepository;
            this.userRepository = userRepository;
        }
        public decimal GetAllRentCost(string userName)
        {
            try
            {
                var companyDelegate = mapper.Map<CompanyDelegateDTO>(userRepository.GetAll().FirstOrDefault(x => x.Login == userName).CompanyDelegate);
                var orders = mapper.Map<IEnumerable<OrderDTO>>(orderRepository.GetAll());
                var autoInOrder=orders.Where(x=>x.Auto.CompanyDelegateId==companyDelegate.Id).ToList();
                return autoInOrder.Sum(x=>x.Auto.Price);
            }
            catch
            {
                return -1;
            }
        }

        public string GetMostRentAuto(string userName)
        {
            try
            {
                var companyDelegate = mapper.Map<CompanyDelegateDTO>(userRepository.GetAll().FirstOrDefault(x => x.Login == userName).CompanyDelegate);
                var orders = mapper.Map<IEnumerable<OrderDTO>>(orderRepository.GetAll());
                var autoInOrder = orders.ToList().Where(x => x.Auto.CompanyDelegateId == companyDelegate.Id).GroupBy(x => x.Auto.Name).Select(g => new { Name = g.Key, Count = g.Count() }).OrderBy(x=>x.Count).ToList();
                return autoInOrder[0].Name;
            }
            catch
            {
                return null;
            }
        }

        public int GetRentCount(string userName)
        {
            try
            {
                var companyDelegate = mapper.Map<CompanyDelegateDTO>(userRepository.GetAll().FirstOrDefault(x => x.Login == userName).CompanyDelegate);
                var orders = mapper.Map<IEnumerable<OrderDTO>>(orderRepository.GetAll());
                var autoInOrder = orders.Where(x => x.Auto.CompanyDelegateId == companyDelegate.Id).ToList();
                return autoInOrder.Count;
            }
            catch
            {
                return -1;
            }
        }
    }
}
