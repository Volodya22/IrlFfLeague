using System;
using System.Linq;
using IrlFfLeague.DataLayer;
using IrlFfLeague.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace IrlFfLeague.Web.Filters
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class PopulateUsersPopulatorAttribute : Attribute
    {
    }

    public class UsersPopulatorAttribute : DropdownPopulatorAttribute
    {
        public UsersPopulatorAttribute() : base(typeof(PopulateUsersPopulatorAttribute))
        {
        }

        protected override SelectListItem[] Populate(ActionExecutedContext filterContext)
        {
            using (var model = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>()))
            {
                return model.Users.Select(m =>
                    new SelectListItem
                    {
                        Text = m.Name,
                        Value = m.Id.ToString()
                    }).ToArray();
            }
        }
    }
}
