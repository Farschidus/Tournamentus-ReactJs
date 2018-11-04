using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tournamentus.Core.Data
{
    public partial class Type
    {
        [Key, Required, StringLength(16)]
        public string TypeName { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
        public virtual ICollection<Tournament> Tournaments { get; set; }
    }
}
