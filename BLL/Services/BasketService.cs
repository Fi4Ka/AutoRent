using AutoMapper;
using AutoRentWeb.DAL.Interfaces;
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
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class BasketService : IBasketService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Arendator> _arendatoRepository;
        private readonly IRepository<Auto> _autoRepository;
        private readonly IRepository<Order> _orderRepository;
        private readonly IMapper mapper;

        public BasketService(IRepository<User> userRepository, IRepository<Auto> autoRepository, IRepository<Arendator> arendatoRepository,IMapper mapper, IRepository<Order> _orderRepository)
        {
            _userRepository = userRepository;
            _autoRepository = autoRepository;
            _arendatoRepository= arendatoRepository;
            this._orderRepository = _orderRepository;
            this.mapper = mapper;
        }
        public IEnumerable<BasketDTO> Get()
        {
            throw new NotImplementedException();
        }

        public async Task<IBaseResponse<OrderViewModel>> GetItem(string userName, int id)
        {
            try
            {
                var arendator = mapper.Map<ArendatorDTO>(_arendatoRepository.GetAll().FirstOrDefault(x => x.User.Login == userName));

                if (arendator == null)
                {
                    return new BaseResponse<OrderViewModel>()
                    {
                        Description = "Пользователь не найден",
                        StatusCode = StatusCode.UserNotFound
                    };
                }

                var order = arendator.Basket?.Orders.Where(x => x.Id == id).ToList();
                if (order == null || order.Count == 0)
                {
                    return new BaseResponse<OrderViewModel>()
                    {
                        Description = "Заказов нет",
                        StatusCode = StatusCode.OrderNotFound
                    };
                }

                var response = order.Select(x => new OrderViewModel()
                {
                    ArendatorAdress = x.Basket.Arendator.Adress,
                    Description = GetAutoDTOById(x.AutoId).Description,
                    DateStart = x.DateStart,
                    DateEnd = x.DateEnd,
                    ArendatorName = x.Basket.Arendator.Name,
                    CompanyDelegateName = GetAutoDTOById(x.AutoId).CompanyDelegate.Name,
                    CompanyDelegateTelephone = GetAutoDTOById(x.AutoId).CompanyDelegate.PhoneNumber,
                    ArendatorPhoneNumber = x.Basket.Arendator.PhoneNumber,
                    AutoName = GetAutoDTOById(x.AutoId).Name,
                    AvatarUrl = GetAutoDTOById(x.AutoId).AvatarUrl,
                    CompanyName = GetAutoDTOById(x.AutoId).CompanyDelegate.Company.Name,
                    TypeCar = GetAutoDTOById(x.AutoId).TypeCar.Name,
                    Id = x.Id,
                    Price = GetAutoDTOById(x.AutoId).Price,
                    StatusOrder = x.StatusOrder,
                    Year = GetAutoDTOById(x.AutoId).Year
                }).ToList();

                return new BaseResponse<OrderViewModel>()
                {
                    Data = response[0],
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<OrderViewModel>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<OrderViewModel>>> GetItems(string userName)
        {
            try
            {
                var arendator = mapper.Map<ArendatorDTO>(_arendatoRepository.GetAll().FirstOrDefault(x => x.User.Login == userName));

                if (arendator == null)
                {
                    return new BaseResponse<IEnumerable<OrderViewModel>>()
                    {
                        Description = "Пользователь не найден",
                        StatusCode = StatusCode.UserNotFound
                    };
                }

                var orders = arendator.Basket?.Orders;
                var upStatusOrders=orders.Where(x => x.StatusOrderEn == StatusOrder.Active && DateTime.Compare(x.DateEnd,DateTime.Now)<0).ToList();
                if(upStatusOrders.Count!=0)
                {
                    foreach (var item in upStatusOrders)
                    {
                        await _orderRepository.Update(mapper.Map<Order>(item));
                    }
                }
                var response = orders.Select(x => new OrderViewModel()
                {
                    ArendatorAdress=x.Basket.Arendator.Adress,
                    Description=GetAutoDTOById(x.AutoId).Description,
                    DateStart = x.DateStart,
                    DateEnd =x.DateEnd,
                    ArendatorName=x.Basket.Arendator.Name,
                    CompanyDelegateName= GetAutoDTOById(x.AutoId).CompanyDelegate.Name,
                    CompanyDelegateTelephone=GetAutoDTOById(x.AutoId).CompanyDelegate.PhoneNumber,
                    ArendatorPhoneNumber=x.Basket.Arendator.PhoneNumber,
                    AutoName=GetAutoDTOById(x.AutoId).Name,
                    AvatarUrl=GetAutoDTOById(x.AutoId).AvatarUrl,
                    CompanyName=GetAutoDTOById(x.AutoId).CompanyDelegate.Company.Name,
                    TypeCar=GetAutoDTOById(x.AutoId).TypeCar.Name,
                    Id=x.Id,
                    Price=GetAutoDTOById(x.AutoId).Price,
                    StatusOrder=x.StatusOrder,
                    Year=GetAutoDTOById(x.AutoId).Year
                }).ToList();

                return new BaseResponse<IEnumerable<OrderViewModel>>()
                {
                    Data = response,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<OrderViewModel>>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
           
        }
        private AutoDTO GetAutoDTOById(int id)
        {
            return mapper.Map<AutoDTO>(_autoRepository.GetAll().FirstOrDefault(x => x.Id == id));
        }
    }
}
