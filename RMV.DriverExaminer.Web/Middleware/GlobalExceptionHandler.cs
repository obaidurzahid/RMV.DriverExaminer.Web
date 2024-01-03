using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace RMV.DriverExaminer.Web.Middleware
{
    public sealed class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
        {
            var errorResponse = new ErrorResponse();
            // System Exception List https://www.completecsharptutorial.com/basic/complete-system-exception.php
            switch (true)
            {
                case bool _ when exception is UnauthorizedAccessException:
                    errorResponse.StatusCode = (int)HttpStatusCode.Unauthorized;
                    errorResponse.Message = "Unauthorized Access";
                    break;

                case bool _ when exception is ApplicationException:
                    errorResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                    errorResponse.Message = "Application Exception Occured";
                    break;

                case bool _ when exception is FileNotFoundException:
                    errorResponse.StatusCode = (int)HttpStatusCode.NotFound;
                    errorResponse.Message = "The requested resource is not found";
                    break;

                case bool _ when exception is InvalidOperationException:
                    errorResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                    errorResponse.Message = "Invalid Operation Occured";
                    break;

                default:
                    errorResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                    errorResponse.Message = "Internal Server Error, Please contact to Administrator";
                    break;
            }

            _logger.LogError($"GlobalExceptionFilter: Error in {httpContext.Request.Method} {httpContext.Request.Path}. " +
                                                               $"Status Code: {errorResponse.StatusCode}. " +
                                                               $"Message: {exception.Message} "+
                                                               $"Type:  {exception.GetType().Name}");
                                                                //$" Stack Trace: {exception.StackTrace}"

            var problemDetails = new ProblemDetails
            {
                Detail = $"{errorResponse.Message}. Error path: {httpContext.Request.Path}"

            };

            httpContext.Response.StatusCode = errorResponse.StatusCode;

            await httpContext.Response
                .WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }
    }
    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
    }

}
