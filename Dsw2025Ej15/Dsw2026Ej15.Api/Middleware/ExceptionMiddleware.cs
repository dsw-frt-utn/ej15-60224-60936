using System.Net;
using System.Text.Json;
using Dsw2026Ej15.Domain.Exceptions;

namespace Dsw2026Ej15.Api.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            //Pasamos la petición al componente
            await _next(context);
        }
        catch (NotFoundException ex)
        {
            //Salta nuestra excepción, devolvemos NotFound 404
            await HandleExceptionAsync(context, ex, HttpStatusCode.NotFound);
        }
        catch (Exception ex)
        {
            //Si salta cualquier otro error, devuelve 500
            await HandleExceptionAsync(context, ex, HttpStatusCode.InternalServerError);
        }
    }

    public static Task HandleExceptionAsync(HttpContext context, Exception exception, HttpStatusCode statusCode)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        //Estructura que ve el cliente del error
        var response = new
        {
            statusCode = context.Response.StatusCode,
            message = exception.Message,
            Error = statusCode.ToString()
        };

        var json = JsonSerializer.Serialize(response);
        return context.Response.WriteAsync(json);
    }
}