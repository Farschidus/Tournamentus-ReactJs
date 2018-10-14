using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tournamentus.Core.Model
{
    public partial class Playoff
    {
        [Key, StringLength(16)]
        public string PlayoffTitle { get; set; }

        public virtual ICollection<TournamentTeam> TournamentTeams { get; set; }
    }
}
