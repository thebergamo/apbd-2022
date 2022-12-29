using UniversityAPI.Middlewares;

namespace UniversityAPI.Extensions;

public static class ExceptionMiddlewareExtensions
{

    public static void ConfigureExceptionHandler(this WebApplication app)
    {
        app.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}