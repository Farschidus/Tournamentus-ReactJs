using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tournamentus.Core.Data
{
    public partial class Group
    {
        [Key, Required, StringLength(16)]
        public string GroupName { get; set; }

        public virtual ICollection<TournamentTeam> TournamentTeams { get; set; }
    }
}
