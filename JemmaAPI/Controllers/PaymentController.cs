using JemmaAPI.Entities.Payments;
using JemmaAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JemmaAPI.Controllers;

public class PaymentController(IPaymentRepository repository) : ControllerBase
{
    /// <summary>
    /// Creates a payment
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Guid))]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IResult> CreatePayment([FromBody] CreatePaymentRequest request)
    {
        return await repository.CreatePayment(request);
    }
    
    /// <summary>
    /// Retrieves a list of payments.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PaymentDto>))]
    public async Task<IResult> GetPayments(int page, int pageSize, string search)
    {
        return await repository.GetPayments(page, pageSize, search);
    }
    
    /// <summary>
    /// Retrieves the details of a payment by its ID.
    /// </summary>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK,  Type = typeof(PaymentDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IResult> GetPayment([FromRoute] Guid id)
    {
        return await repository.GetPayment(id);
    }

    /// <summary>
    /// Updates the details of a payment by its ID.
    /// </summary>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent,  Type = typeof(PaymentDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    public async Task<IResult> UpdatePayment([FromRoute] Guid id, [FromBody] CreatePaymentRequest payment)
    {
        return await repository.UpdatePayment(id, payment);
    }
    
    /// <summary>
    /// Deletes a payment by its ID.
    /// </summary>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent,  Type = typeof(PaymentDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IResult> DeletePayment([FromRoute] Guid id)
    {
        return await repository.DeletePayment(id);
    }
}