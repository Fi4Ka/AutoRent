using AutoMapper;
using AutoRentWeb.DAL.Interfaces;
using AutoRentWeb.DAL.Repositories;
using AutoRentWebDomain.Entity;
using AutoRentWebDomain.Enum;
using AutoRentWebDomain.Interfaces;
using AutoRentWebDomain.Response;
using AutoRentWebDomain.ViewModels.Order;
using BLL.DTO;
using BLL.Interfaces.EntityServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Arendator> _arendatorRepository;
        private readonly IRepository<Auto> _autoRepository;
        private readonly IRepository<Order> _orderRepository;
        private readonly IArendatorService arendatorService;
        private readonly IMapper mapper;

        public OrderService(IRepository<Arendator> arendatorRepository, IRepository<User> _userRepository, IRepository<Order> orderRepository, IArendatorService arendatorService, IRepository<Auto> autoRepository)
        {
            _arendatorRepository = arendatorRepository;
            _orderRepository = orderRepository;
            this.arendatorService = arendatorService;
            _autoRepository = autoRepository;
            this._userRepository = _userRepository;
        }
        public async Task<IBaseResponse<OrderDTO>> Create(CreateOrderViewModel model)
        {
            try
            {
                var arendator = _userRepository.GetAll().FirstOrDefault(x=>x.Login==model.Login);
                if (arendator == null)
                {
                    return new BaseResponse<OrderDTO>()
                    {
                        Description = "Пользователь не найден",
                        StatusCode = StatusCode.UserNotFound
                    };
                }
                var ie = arendator.Arendator.Basket?.Id;

                var order = new OrderDTO()
                {
                   DateStart=DateTime.Now,
                   AutoId=model.CarId,
                   StatusOrderEn= StatusOrder.Active,
                   BasketId= (int)ie,
                   DateEnd=DateTime.Now.AddDays(model.DayQuantity),
                };

                await _orderRepository.Create(new Order() { 
                DateEnd=order.DateEnd,
                DateStart=order.DateStart,
                AutoId=order.AutoId,
                BasketId=order.BasketId,
                StatusOrder= order.StatusOrderEn,
                });

                return new BaseResponse<OrderDTO>()
                {
                    Description = "Заказ создан",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<OrderDTO>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public IEnumerable<OrderDTO> Get()
        {
            throw new NotImplementedException();
        }
    }
}
