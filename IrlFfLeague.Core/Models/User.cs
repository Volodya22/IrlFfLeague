using System.Collections.Generic;

namespace IrlFfLeague.Core.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}
