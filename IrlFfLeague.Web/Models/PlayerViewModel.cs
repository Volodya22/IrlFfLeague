using IrlFfLeague.Core.Models;
using IrlFfLeague.Web.Infrastructure.Mapping;

namespace IrlFfLeague.Web.Models
{
    public class PlayerViewModel : IMapFrom<Player>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
