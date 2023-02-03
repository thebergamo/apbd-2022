using DoctorsAPI.Middlewares;

namespace DoctorsAPI.Extensions;

public static class TransactionMiddlewareExtensions
{

    public static void UseTransactionHandler(this IApplicationBuilder app)
    {
        app.UseMiddleware<TransactionHandlerMiddleware>();
    }
    
}