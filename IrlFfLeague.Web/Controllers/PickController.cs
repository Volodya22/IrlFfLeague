using System.Linq;
using AutoMapper.QueryableExtensions;
using IrlFfLeague.Core.Models;
using IrlFfLeague.DataLayer;
using IrlFfLeague.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace IrlFfLeague.Web.Controllers
{
    public class PickController : BaseController
    {
        private readonly IDbContext _context;

        public PickController(IDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new UsersViewModel();

            return View(model);
        }

        public IActionResult Table(int userId, League league)
        {
            var model = _context.Picks.Where(p => p.UserId == userId).OrderByDescending(p => p.Matchday)
                .ProjectTo<PickViewModel>().FirstOrDefault();

            return PartialView(model);
        }
    }
}