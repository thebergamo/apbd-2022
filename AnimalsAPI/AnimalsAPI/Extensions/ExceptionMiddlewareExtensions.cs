using AnimalsAPI.Middlewares;

namespace AnimalsAPI.Extensions;

public static class ExceptionMiddlewareExtensions
{

    public static void ConfigureExceptionHandler(this WebApplication app)
    {
        app.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}