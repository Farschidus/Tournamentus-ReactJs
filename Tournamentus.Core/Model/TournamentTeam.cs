using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tournamentus.Core.Model
{
    public partial class TournamentTeam
    {
        [Key]
        public int TournamentTeamId { get; set; }
        public short TournamentId { get; set; }
        public short TeamId { get; set; }
        [Required, StringLength(16)]
        public string GroupName { get; set; }
        [Required, StringLength(16)]
        public string PlayoffTitle { get; set; }
        [StringLength(256)]
        public string InGroupResults { get; set; }

        public virtual ICollection<Match> HomeMatches { get; set; }
        public virtual ICollection<Match> AwayMatches { get; set; }
        [ForeignKey("GroupName")]
        public virtual Group Group { get; set; }
        [ForeignKey("PlayoffTitle")]
        public virtual Playoff Playoff { get; set; }
        [ForeignKey("TeamId")]
        public virtual Team Team { get; set; }
        [ForeignKey("TournamentId")]
        public virtual Tournament Tournament { get; set; }


    }
}
