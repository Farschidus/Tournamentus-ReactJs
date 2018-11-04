using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tournamentus.Core.Data
{
    public partial class Team
    {
        [Key]
        public short TeamId { get; set; }
        [Required, StringLength(16)]
        public string TypeName { get; set; }
        [Required, StringLength(16)]
        public string RegionName { get; set; }
        [Required, StringLength(32)]
        public string Name { get; set; }
        [Required, StringLength(8)]
        public string Abbreviation { get; set; }
        [Required, StringLength(32)]
        public string Image { get; set; }

        [ForeignKey("RegionName")]
        public virtual Region Region { get; set; }
        [ForeignKey("TypeName")]
        public virtual Type Type { get; set; }
        public virtual ICollection<TournamentTeam> TournamentTeams { get; set; }
    }
}
