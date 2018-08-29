using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace IrlFfLeague.Core.Models
{
    public class Pick
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int PlayerId { get; set; }

        public int Matchday { get; set; }

        public Scheme Scheme { get; set; }

        public virtual ICollection<PlayerInPick> PlayerInPicks { get; set; }
    }
}
