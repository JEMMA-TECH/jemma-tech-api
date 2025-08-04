using JemmaAPI.Entities.Base;
using JemmaAPI.Entities.Orders;

namespace JemmaAPI.Interfaces;

public interface IOrderRepository
{
    Task<Result<Guid>> CreateOrder(CreateOrderRequest request);
    Task<Result<IEnumerable<OrderDto>>> GetOrders(int page, int pageSize, string search);
    Task<Result<OrderDto>> GetOrder(Guid id);
    Task<Result<OrderDto>> UpdateOrder(Guid id, CreateOrderRequest request);
    Task<Result<bool>> DeleteOrder(Guid id);

}