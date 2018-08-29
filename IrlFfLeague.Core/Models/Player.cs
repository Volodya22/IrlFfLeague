using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace IrlFfLeague.Core.Models
{
    /// <summary>
    /// Класс игрока
    /// </summary>
    public class Player
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? UserId { get; set; }

        public int ClubId { get; set; }

        public string Name { get; set; }

        public string Link { get; set; }

        public Position MainPosition { get; set; }

        public Position? FirstPosition { get; set; }

        public Position? SecondPosition { get; set; }

        public bool IsInjured { get; set; }

        public virtual User User { get; set; }

        public virtual Club Club { get; set; }

        public virtual ICollection<PlayerInPick> PlayerInPicks { get; set; }
    }
}
