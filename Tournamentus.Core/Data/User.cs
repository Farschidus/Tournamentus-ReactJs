using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tournamentus.Core.Data
{
    public partial class User
    {
        public const int NameMaxLength = 256;
        public const int EmailMaxLength = 256;
        public const int PasswordHashMaxLength = 64;
        public const int PasswordSaltMaxLength = 128;
        public const int PasswordMinLength = 6;

        [Key]
        public int UserId { get; set; }

        [Required, StringLength(50)]
        public string TimezoneId { get; set; }

        [StringLength(EmailMaxLength)]
        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        [NotMapped, MinLength(PasswordMinLength)]
        public string Password { get; set; }

        [Required, MaxLength(PasswordHashMaxLength)]
        public byte[] PasswordHash { get; set; }

        [Required, MaxLength(PasswordSaltMaxLength)]
        public byte[] PasswordSalt { get; set; }

        [StringLength(512)]
        public string SecurityStamp { get; set; }

        [StringLength(128)]
        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public DateTime? LockoutEndDateUtc { get; set; }

        public bool LockoutEnabled { get; set; }

        public int AccessFailedCount { get; set; }

        [Required, StringLength(256)]
        public string UserName { get; set; }

        [StringLength(NameMaxLength)]
        public string FirstName { get; set; }

        [StringLength(NameMaxLength)]
        public string LastName { get; set; }

        public System.DateTime DateCreated { get; set; }

        public System.DateTime DateUpdated { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public DateTime? PasswordChangeDate { get; set; }

        [ForeignKey("TimezoneId")]
        public virtual Timezone Timezone { get; set; }
        public virtual ICollection<UserClaim> UserClaims { get; set; }
        public virtual ICollection<UserLogin> UserLogins { get; set; }
        public virtual ICollection<UserPrediction> UserPredictions { get; set; }
        public virtual ICollection<TournamentUser> TournamentUsers { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
