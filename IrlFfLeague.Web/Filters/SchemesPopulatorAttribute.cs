using System;
using System.Collections.Generic;
using IrlFfLeague.Core.Models;
using IrlFfLeague.Services;
using IrlFfLeague.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IrlFfLeague.Web.Filters
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class PopulateSchemesPopulatorAttribute : Attribute
    {
    }

    public class SchemesPopulatorAttribute : DropdownPopulatorAttribute
    {
        public SchemesPopulatorAttribute() : base(typeof(PopulateLeaguesPopulatorAttribute))
        {
        }

        protected override SelectListItem[] Populate(ActionExecutedContext filterContext)
        {
            var result = new List<SelectListItem>();

            foreach (Scheme scheme in Enum.GetValues(typeof(Scheme)))
            {
                result.Add(new SelectListItem
                {
                    Text = EnumToStringService.SchemeToString(scheme),
                    Value = ((int)scheme).ToString()
                });
            }

            return result.ToArray();
        }
    }
}
