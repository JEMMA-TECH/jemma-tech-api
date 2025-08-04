using JemmaAPI.Entities.Base;
using JemmaAPI.Entities.Payments;

namespace JemmaAPI.Interfaces;

public interface IPaymentRepository
{
    Task<Result<Guid>> CreatePayment(CreatePaymentRequest request);
    Task<Result<List<PaymentDto>>> GetPayments(int page, int pageSize, string search);
    Task<Result<PaymentDto>> GetPayment(Guid id);
    Task<Result<PaymentDto>> UpdatePayment(Guid id, CreatePaymentRequest payment);
    Task<Result<bool>> DeletePayment(Guid id);
}