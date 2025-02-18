using Application.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Common
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;

        public ApiExceptionFilterAttribute()
        {
            _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
            {
                { typeof(DuplicateEntityException), HandleDuplicateEntityException }
            };
        }

        public override void OnException(ExceptionContext context)
        {
            Type type = context.Exception.GetType();
            if (_exceptionHandlers.ContainsKey(type))
            {
                _exceptionHandlers[type].Invoke(context);
                return;
            }
            base.OnException(context);
        }

        private void HandleDuplicateEntityException(ExceptionContext context)
        {
            var exception = context.Exception as DuplicateEntityException;
            var details = new ProblemDetails
            {
                Type = typeof(DuplicateEntityException).ToString(),
                Detail = exception.Message
            };
            context.Result = new ObjectResult(details)
            {
                StatusCode = StatusCodes.Status409Conflict
            };
            context.ExceptionHandled = true;
        }
    }
}
