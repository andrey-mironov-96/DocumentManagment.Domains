using DocumentManagment.Domains.Errors;
using Microsoft.Extensions.Logging;

namespace DocumentManagment.Domains.Extensions;

public class ErrorLogger<T>(ILoggerFactory factory) : Logger<T>(factory)

{
    public void PrintError(Error error)
    {
        this.LogError("ErrorCode: {code}; Description: {descr}.", error.Code, error.Description);
    }
}

public static class ILoggerExtenstions
{
    public static void LogError(this ILogger logger, Error error)
    {
        logger.LogError("ErrorCode: {code}; Description: {descr}.", error.Code, error.Description);
    }

    public static void LogError<T>(this ILogger<T> logger, Error error)
    {
        logger.LogError("ErrorCode: {code}; Description: {descr}.", error.Code, error.Description);
    }
}
