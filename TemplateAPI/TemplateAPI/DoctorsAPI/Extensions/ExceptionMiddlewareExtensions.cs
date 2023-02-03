using DoctorsAPI.Middlewares;

namespace DoctorsAPI.Extensions;

public static class ExceptionMiddlewareExtensions
{

    public static void UseExceptionHandler(this WebApplication app)
    {
        app.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}