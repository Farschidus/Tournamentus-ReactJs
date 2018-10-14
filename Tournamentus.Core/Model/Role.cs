using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tournamentus.Core.Model
{
    public partial class Role
    {
        [Key]
        public int RoleId { get; set; }
        [Required, StringLength(256)]
        public string Name { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
