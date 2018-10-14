using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tournamentus.Core.Model
{
    public partial class UserClaim
    {
        [Key]
        public int UserClaimId { get; set; }
        public int UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
