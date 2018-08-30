using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IrlFfLeague.Web.Infrastructure
{
    public abstract class DropdownPopulatorAttribute : ActionFilterAttribute
    {
        private readonly Type _markerAttributeType;

        protected DropdownPopulatorAttribute(Type markerAttributeType)
        {
            _markerAttributeType = markerAttributeType;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var viewResult = filterContext.Result as ViewResult;

            if (viewResult == null)
            {
                var alertResult = filterContext.Result as AlertDecoratorResult;
                if (alertResult != null)
                    viewResult = alertResult.InnerResult as ViewResult;
            }

            if (viewResult != null && viewResult.Model != null)
            {
                var hasProperty = ReflectionHelper.HasPropertyWithAttribute(viewResult.Model, _markerAttributeType);
                if (hasProperty)
                {
                    viewResult.ViewData[_markerAttributeType.Name] = Populate(filterContext);
                }
            }
        }

        protected abstract SelectListItem[] Populate(ActionExecutedContext filterContext);
    }
}
