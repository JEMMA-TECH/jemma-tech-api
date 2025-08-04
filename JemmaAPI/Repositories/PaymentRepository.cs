using System.Net;
using AutoMapper;
using JemmaAPI.Constants;
using JemmaAPI.Context;
using JemmaAPI.Entities.Base;
using JemmaAPI.Entities.Payments;
using JemmaAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JemmaAPI.Repositories;

public class PaymentRepository(ApplicationDbContext context, IMapper mapper) : IPaymentRepository
{
    public async Task<Result<Guid>> CreatePayment(CreatePaymentRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<List<PaymentDto>>> GetPayments(int page, int pageSize, string search)
    {
        var query = context.Payments.AsQueryable();
        // return new Result<List<PaymentDto>>(HttpStatusCode.OK, Messages.CustomerAlreadyExistsMessage,
        //     data: mapper.Map(query.ToList()));
        return new Result<List<PaymentDto>>(HttpStatusCode.OK, Messages.CustomerAlreadyExistsMessage);
    }

    public async Task<Result<PaymentDto>> GetPayment(Guid id)
    {
        var payment = await context.Payments.FirstOrDefaultAsync(p => p.Id == id);
        return payment is null ? new Result<PaymentDto>(HttpStatusCode.NotFound,Messages.CustomerAlreadyExistsMessage,false) :
            new Result<PaymentDto>(HttpStatusCode.OK,Messages.CustomerAlreadyExistsMessage,true,mapper.Map<PaymentDto>(payment));
        
    }

    public async Task<Result<PaymentDto>> UpdatePayment(Guid id, CreatePaymentRequest payment)
    {
        throw new NotImplementedException();
    }
    

    public async Task<Result<bool>> DeletePayment(Guid id)
    {
        var payment = await context.Payments.FirstOrDefaultAsync(p => p.Id == id);
        if (payment is null) return new Result<bool>(HttpStatusCode.NotFound,Messages.PaymentNotFound);
        
        var order = await context.Orders.FirstOrDefaultAsync(o => o.Id == payment.OrderId);
        
        //TODO: cannot delete payment linked to an order
        if (order != null) return new Result<bool>(HttpStatusCode.BadRequest,Messages.PaymentCannotBeDeleted,false);
        
        context.Payments.Remove(payment);
        await context.SaveChangesAsync();
        return new Result<bool>(HttpStatusCode.OK,Messages.PaymentDeleted);
    }
}