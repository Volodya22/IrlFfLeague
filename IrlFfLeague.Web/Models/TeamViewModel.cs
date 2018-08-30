using System.ComponentModel.DataAnnotations;
using IrlFfLeague.Web.Filters;

namespace IrlFfLeague.Web.Models
{
    public class TeamViewModel
    {
        [PopulateLeaguesPopulator]
        [UIHint("SimpleDropdown")]
        public int User { get; set; }
    }
}
