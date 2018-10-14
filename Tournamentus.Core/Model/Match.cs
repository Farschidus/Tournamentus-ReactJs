using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tournamentus.Core.Model
{
    public partial class Match
    {
        [Key]
        public int MatchId { get; set; }
        [Required]
        public int HomeTeamId { get; set; }
        [Required]
        public int GuestTeamId { get; set; }
        [StringLength(8)]
        public string Result { get; set; }
        public DateTime? DateAndTime { get; set; }

        [ForeignKey("HomeTeamId")]
        public virtual TournamentTeam HomeTeam { get; set; }
        [ForeignKey("GuestTeamId")]
        public virtual TournamentTeam GuestTeam { get; set; }
        public virtual ICollection<UserPrediction> UserPredictions { get; set; }
    }
}
