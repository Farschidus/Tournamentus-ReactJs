using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tournamentus.Core.Data
{
    public partial class Timezone
    {
        [Key, Required, StringLength(50)]
        public string TimezoneId { get; set; }
        public int BaseUtcOffsetInMinutes { get; set; }
        [Required, StringLength(100)]
        public string DisplayName { get; set; }

        public virtual ICollection<Tournament> Tournaments { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
