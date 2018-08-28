using System.Collections.Generic;

namespace IrlFfLeague.Core.Models
{
    public class Pick
    {
        public int Id { get; set; }

        public int PlayerId { get; set; }

        public int Matchday { get; set; }

        public Scheme Scheme { get; set; }

        public virtual ICollection<PlayerInPick> PlayerInPicks { get; set; }
    }
}
