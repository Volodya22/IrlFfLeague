using IrlFfLeague.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace IrlFfLeague.Web.Controllers
{
    public class TeamController : BaseController
    {
        public IActionResult Index()
        {
            var model = new TeamViewModel();

            return View(model);
        }
    }
}