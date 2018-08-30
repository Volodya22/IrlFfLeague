using System;
using System.Collections.Generic;
using System.Linq;
using IrlFfLeague.Core.Models;
using IrlFfLeague.Services;
using IrlFfLeague.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IrlFfLeague.Web.Filters
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class PopulateLeaguesPopulatorAttribute : Attribute
    {
    }

    public class LeaguesPopulatorAttribute : DropdownPopulatorAttribute
    {
        public LeaguesPopulatorAttribute() : base(typeof(PopulateLeaguesPopulatorAttribute))
        {
        }

        protected override SelectListItem[] Populate(ActionExecutedContext filterContext)
        {
            var result = new List<SelectListItem>();

            foreach (League league in Enum.GetValues(typeof(League)))
            {
                result.Add(new SelectListItem
                {
                    Text = EnumToStringService.LeagueToString(league),
                    Value = ((int)league).ToString()
                });
            }

            return result.ToArray();
        }
    }
}
