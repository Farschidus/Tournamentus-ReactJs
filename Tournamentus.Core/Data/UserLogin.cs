using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tournamentus.Core.Data
{
    public partial class UserLogin
    {
        [Key, Column(Order = 1), Required, StringLength(128)]
        public string LoginProvider { get; set; }
        [Key, Column(Order = 2), Required, StringLength(128)]
        public string ProviderKey { get; set; }
        [Key, Column(Order = 3), Required, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
