using DoctorsAPI.Annotations;
using DoctorsAPI.Models;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore.Storage;

namespace DoctorsAPI.Middlewares;

public class TransactionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<TransactionHandlerMiddleware> _logger;

    public TransactionHandlerMiddleware(RequestDelegate next, ILogger<TransactionHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext, MasterDbContext dbContext)
    {
        if (HasTransactionalContext(httpContext))
        {
            await HandleTransaction(httpContext, dbContext);
        }
        else
        {
            await _next(httpContext);
        }
    }

    private async Task HandleTransaction(HttpContext httpContext, MasterDbContext dbContext)
    {
        await using var transaction = await dbContext.Database.BeginTransactionAsync();
        _logger.LogInformation("Transaction Begin");

        try
        {
            await _next(httpContext);
            await Commit(httpContext, transaction);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Transaction Failed with error: {ex.Message}");
            await Rollback(transaction);
        }
    }

    private async Task Commit(HttpContext httpContext, IDbContextTransaction transaction)
    {
        var savePointName = $"transactional_request_{httpContext.Request.Headers.RequestId}";
        await transaction.CreateSavepointAsync(savePointName);

        if (httpContext.Response.StatusCode is >= 200 and < 300)
        {
            await transaction.CommitAsync();
            _logger.LogInformation("Transaction Committed");
        }
        else
        {
            await Rollback(transaction, savePointName);
        }
    }

    private async Task Rollback(IDbContextTransaction transaction, string? savePointName = null)
    {
        if (savePointName is not null)
        {
            await transaction.RollbackToSavepointAsync(savePointName);
        }
        else
        {
            await transaction.RollbackAsync();
        }
        _logger.LogInformation("Transaction rollback");

    }

    private static bool HasTransactionalContext(HttpContext httpContext)
    {
        var endpoint = httpContext.Features.Get<IEndpointFeature>()?.Endpoint;
        return endpoint?.Metadata.GetMetadata<TransactionalAttribute>() != null;
    }
}