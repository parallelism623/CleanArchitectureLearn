
using CleanArchitecture.Domain.Exceptions;

namespace CleanArchitecture.API.Middleware
{
    internal sealed class ExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                await HandleExceptionAsync(context, e);
            }
        }
        public static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var statusCode = GetStatusCode(exception);
            var response = new
            {
                title = GetTitle(exception),
                status = statusCode,
                detail = exception.Message,
                errors = GetErrors(exception),
            };
        }
        public static int GetStatusCode(Exception exception) =>
        exception switch
        {
            BadRequestException => StatusCodes.Status400BadRequest,
            NotFoundException => StatusCodes.Status404NotFound,
            FluentValidation.ValidationException => StatusCodes.Status400BadRequest,
            FormatException => StatusCodes.Status422UnprocessableEntity,
            _ => StatusCodes.Status500InternalServerError
        };

        public static string GetTitle(Exception exception) =>
        exception switch
        {
            DomainException applicationException => applicationException.Title,
            _ => "Server Error"
        };
        public static IReadOnlyCollection<Application.Exceptions.ValidationError> GetErrors(Exception exception)
        {
            IReadOnlyCollection<Application.Exceptions.ValidationError> errors = null;

            if (exception is Application.Exceptions.ValidationException validationException)
            {
                errors = validationException.Errors;
            }

            return errors;
        }
    }
}
