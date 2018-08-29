using System.ComponentModel.DataAnnotations.Schema;

namespace IrlFfLeague.Core.Models
{
    public class PlayerInPick
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int PlayerId { get; set; }

        public int PickId { get; set; }

        public Position Position { get; set; }

        public int Minutes { get; set; }

        public int YellowCards { get; set; }

        public int RedCards { get; set; }

        public int OwnGoals { get; set; }

        public int NotScoredPenalties { get; set; }

        public int Goals { get; set; }

        public int GoalPasses { get; set; }

        public int TakenPenalties { get; set; }

        public int MissedGoals { get; set; }

        public bool MVP { get; set; }

        public virtual Player Player { get; set; }

        public virtual Pick Pick { get; set; }
    }
}
