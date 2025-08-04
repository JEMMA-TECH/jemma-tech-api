using AutoMapper;
using JemmaAPI.Entities.Companies;
using JemmaAPI.Entities.Customers;
using JemmaAPI.Entities.Items;
using JemmaAPI.Entities.Orders;
using JemmaAPI.Entities.Payments;
using JemmaAPI.Entities.Services;
using JemmaAPI.Entities.Users;

namespace JemmaAPI.Automapper;

public class Automapper : Profile
{
    public Automapper()
    {
        #region Companies

        CreateMap<Company, CompanyDto>();

        #endregion

        #region Users

        CreateMap<User, UserDto>();

        #endregion

        #region Customers

        CreateMap<CreateCustomerRequest, Customer>();
        CreateMap<Customer, CustomerDto>();

        #endregion

        #region Items

        CreateMap<CreateItemRequest, Item>();
        CreateMap<Item, ItemDto>();

        #endregion
        
        #region Services
        CreateMap<CreateServiceRequest, Service>();
        CreateMap<Service, ServiceDto>();
        #endregion

        #region Orders

        CreateMap<CreateOrderRequest, Order>();
        CreateMap<Order, OrderDto>();

        #endregion
        
        #region Payment
        CreateMap<Payment, PaymentDto>();
        CreateMap<Payment, PaymentDto>();
        #endregion
        
        
    }
    
}