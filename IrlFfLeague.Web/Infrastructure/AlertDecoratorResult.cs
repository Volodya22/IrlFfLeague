using Microsoft.AspNetCore.Mvc;

namespace IrlFfLeague.Web.Infrastructure
{
    public class AlertDecoratorResult : ActionResult
    {
        public ActionResult InnerResult { get; set; }

        public string AlertClass { get; set; }

        public string Message { get; set; }

        public AlertDecoratorResult(ActionResult innerResult,
            string alertClass,
            string message)
        {
            InnerResult = innerResult;
            AlertClass = alertClass;
            Message = message;
        }

        public override void ExecuteResult(ActionContext context)
        {
            InnerResult.ExecuteResult(context);
        }
    }
}
