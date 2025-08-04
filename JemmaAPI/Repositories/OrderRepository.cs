using System.Net;
using AutoMapper;
using JemmaAPI.Constants;
using JemmaAPI.Context;
using JemmaAPI.Entities.Base;
using JemmaAPI.Entities.Orders;
using JemmaAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JemmaAPI.Repositories;

public class OrderRepository(ApplicationDbContext context, IMapper mapper) : IOrderRepository
{
    public async Task<Result<Guid>> CreateOrder(CreateOrderRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<IEnumerable<OrderDto>>> GetOrders(int page, int pageSize, string search)
    {
        var query = context.Orders.AsQueryable();
        return new Result<IEnumerable<OrderDto>>(HttpStatusCode.OK, Messages.OrdersRetrieved,
            data: mapper.Map<IEnumerable<OrderDto>>(await query.ToListAsync()));
    }

    public async Task<Result<OrderDto>> GetOrder(Guid id)
    {
        var order = await context.Orders.FirstOrDefaultAsync(o => o.Id == id);
        return order is null ? new Result<OrderDto>(HttpStatusCode.NotFound,Messages.OrderNotFound,false) :
            new Result<OrderDto>(HttpStatusCode.OK, Messages.OrderRetrieved, data: mapper.Map<OrderDto>(order));
    }

    public async Task<Result<OrderDto>> UpdateOrder(Guid id, CreateOrderRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<bool>> DeleteOrder(Guid id)
    {
        var order = await context.Orders.FirstOrDefaultAsync(o => o.Id == id);
        if (order is null) return new Result<bool>(HttpStatusCode.NotFound,Messages.OrderNotFound);
        
        //TODO: cannot deleted order if payment has been made.
        
        context.Orders.Remove(order);
        await context.SaveChangesAsync();
        return new Result<bool>(HttpStatusCode.OK, Messages.OrderDeleted);
    }
}