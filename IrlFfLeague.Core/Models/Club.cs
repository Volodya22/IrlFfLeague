using System.Collections.Generic;

namespace IrlFfLeague.Core.Models
{
    /// <summary>
    /// Клуб в лиге
    /// </summary>
    public class Club
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public League League { get; set; }

        public string Link { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}
