using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournamentus.Core.Data
{
    public class TournamentUser
    {
        [Key, Column(Order = 1), Required]
        public short TournamentId { get; set; }
        [Key, Column(Order = 2), Required]
        public int UserId { get; set; }

        [ForeignKey("TournamentId")]
        public virtual Tournament Tournament { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
