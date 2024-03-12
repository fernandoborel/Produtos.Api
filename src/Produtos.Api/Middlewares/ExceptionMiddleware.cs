using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Net;
using Produtos.Api.Models;

namespace Produtos.Api.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate? _requestDelegate;

    public ExceptionMiddleware(RequestDelegate? requestDelegate)
    {
        _requestDelegate = requestDelegate;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _requestDelegate(httpContext);
        }
        catch (ApplicationException e)
        {
            await HandleExceptionAsync(httpContext, e);
        }
        catch (Exception e)
        {
            await HandleExceptionAsync(httpContext, e);
        }
    }

    public async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        var errorViewModel = new ErrorViewModel();
        errorViewModel.Errors = new List<string>();

        switch (exception)
        {
            case ApplicationException:
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                errorViewModel.Errors.Add(exception.Message);
                break;

            default:
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                errorViewModel.Errors.Add("Ocorreu um erro interno, entre em contato com o nosso suporte.");
                break;
        }

        errorViewModel.HttpStatus = httpContext.Response.StatusCode;
        httpContext.Response.ContentType = "application/json";

        var settings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(errorViewModel, settings));
    }
}
