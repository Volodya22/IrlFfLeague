using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IrlFfLeague.Core.Models;
using IrlFfLeague.Web.Filters;
using IrlFfLeague.Web.Infrastructure;
using IrlFfLeague.Web.Infrastructure.Mapping;

namespace IrlFfLeague.Web.Models
{
    public class PickViewModel : IMapFrom<Pick>
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int Matchday { get; set; }

        [PopulateSchemesPopulator]
        [UIHint("SimpleDropdown")]
        public Scheme Scheme { get; set; }

        public List<PlayerViewModel> Players { get; set; }
    }
}
