using System.Linq;
using IrlFfLeague.Core.Models;
using IrlFfLeague.DataLayer;
using IrlFfLeague.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IrlFfLeague.Web.Controllers
{
    public class TeamController : BaseController
    {
        private readonly IDbContext _context;

        public TeamController(IDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new TeamViewModel();

            return View(model);
        }

        public IActionResult Table(int userId, League league)
        {
            var players = _context.Players.Where(p => p.UserId == userId && p.Club.League == league).OrderBy(p => p.FirstPosition).Select(p =>
                new SelectListItem
                {
                    Text = p.Name,
                    Value = p.Id.ToString()
                }).ToList();

            return PartialView(players);
        }

        [HttpPost]
        public IActionResult AddPlayer(int userId, int playerId)
        {
            var player = _context.Players.SingleOrDefault(p => p.Id == playerId);

            if (player == null)
            {
                return Json(new
                {
                    success = false
                });
            }

            player.UserId = userId;

            _context.Players.Update(player);
            _context.SaveChanges();

            return Json(new
            {
                success = true,
                id = player.Id,
                name = player.Name
            });
        }

        [HttpPost]
        public IActionResult RemovePlayer(int userId, int playerId)
        {
            var player = _context.Players.SingleOrDefault(p => p.Id == playerId);

            if (player == null)
            {
                return Json(new
                {
                    success = false
                });
            }

            player.UserId = null;

            _context.Players.Update(player);
            _context.SaveChanges();

            return Json(new
            {
                success = true
            });
        }

        public IActionResult GetTeams(League league)
        {
            var teams = _context.Clubs.Where(c => c.League == league).OrderBy(c => c.Name).Select(s => new SelectListItem
            {
                Text = s.Name,
                Value = s.Id.ToString()
            }).ToList();

            return Json(new { teams });
        }

        public IActionResult GetTeamPlayers(int teamId)
        {
            var players = _context.Players.Where(p => p.ClubId == teamId && p.UserId == null).OrderBy(p => p.FirstPosition).Select(s => new SelectListItem
            {
                Text = s.Name,
                Value = s.Id.ToString()
            }).ToList();

            return Json(new { players });
        }
    }
}