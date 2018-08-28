using IrlFfLeague.DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace IrlFfLeague.Web.Controllers
{
    public class ResultsController : Controller
    {
        private readonly IDbContext _context;

        public ResultsController(IDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Table()
        {
            return View();
        }
    }
}