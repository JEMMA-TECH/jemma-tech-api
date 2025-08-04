using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace JemmaAPI.Entities.Base;

public class Result<T>( HttpStatusCode statusCode, string message, bool isSuccess = true, T? data = default)
    : IActionResult, IResult
{
    public bool IsSuccess { get; set; } = isSuccess;
    private HttpStatusCode StatusCode { get; set; } = statusCode;
    public string Message { get; set; } = message;
    public T? Data { get; set; } = data;

    public async Task ExecuteResultAsync(ActionContext context)
    {
        var response = context.HttpContext.Response;
        response.ContentType = "application/json";
        response.StatusCode = (int)StatusCode;

        // to prevent circular references that would cause a request failure
        var options = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.IgnoreCycles
        };

        await response.WriteAsync(JsonSerializer.Serialize(this, options));
    }

    public async Task ExecuteAsync(HttpContext httpContext)
    {
        throw new NotImplementedException();
    }
}