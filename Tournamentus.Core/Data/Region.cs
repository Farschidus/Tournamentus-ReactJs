using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tournamentus.Core.Data
{
    public partial class Region
    {
        [Key, Required, StringLength(16)]
        public string RegionName { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
        public virtual ICollection<Tournament> Tournaments { get; set; }
    }
}
