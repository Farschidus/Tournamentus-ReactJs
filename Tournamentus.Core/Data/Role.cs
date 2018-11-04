using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tournamentus.Core.Data
{
    public partial class Role
    {
        public const int RoleNameMaxLength = 256;
        public const string Administrator = "Administrator";

        [Key]
        public int RoleId { get; set; }

        [Required, MaxLength(RoleNameMaxLength)]
        public string RoleName { get; set; }
    }
}
