using IrlFfLeague.DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace IrlFfLeague.Web.Controllers
{
    public class PickController : Controller
    {
        private readonly IDbContext _context;

        public PickController(IDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}