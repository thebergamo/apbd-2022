using ClientsTripAPI.Middlewares;

namespace ClientsTripAPI.Extensions;

public static class ExceptionMiddlewareExtensions
{

    public static void ConfigureExceptionHandler(this WebApplication app)
    {
        app.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}