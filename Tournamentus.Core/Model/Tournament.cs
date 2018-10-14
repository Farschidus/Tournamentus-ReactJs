using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tournamentus.Core.Model
{
    public partial class Tournament
    {
        [Key]
        public short TournamentId { get; set; }
        [Required, StringLength(16)]
        public string TypeName { get; set; }
        [Required, StringLength(16)]
        public string RegionName { get; set; }
        [Required, StringLength(32)]
        public string Name { get; set; }
        [Required, StringLength(8)]
        public string Abbreviation { get; set; }
        [StringLength(32)]
        public string Image { get; set; }
        [Required, StringLength(50)]
        public string TimezoneId { get; set; }
        public bool IsActive { get; set; }

        public virtual Region Region { get; set; }
        public virtual Timezone Timezone { get; set; }
        public virtual Type Type { get; set; }
        public virtual ICollection<TournamentTeam> TournamentTeams { get; set; }
        public virtual ICollection<TournamentUser> TournamentUsers { get; set; }
    }
}
