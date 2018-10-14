using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tournamentus.Core.Model
{
    public class UserRole
    {
        [Key, Column(Order = 1), Required]
        public int UserId { get; set; }
        [Key, Column(Order = 2), Required]
        public int RoleId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
    }
}
