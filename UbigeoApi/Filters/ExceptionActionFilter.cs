using SinsajoServices.Common.Exceptions;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace UbigeoApi.Filters
{
    public class ExceptionActionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception == null)
            {
                base.OnException(actionExecutedContext);
                return;
            }

            if (actionExecutedContext.Exception is AppException appException)
            {
                actionExecutedContext.Response
                    = actionExecutedContext.Request
                    .CreateErrorResponse(HttpStatusCode.BadRequest, appException.Message);
            }

            base.OnException(actionExecutedContext);
        }

        public override Task OnExceptionAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            return base.OnExceptionAsync(actionExecutedContext, cancellationToken);
        }
    }
}