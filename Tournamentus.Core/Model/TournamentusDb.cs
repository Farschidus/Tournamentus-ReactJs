using Microsoft.EntityFrameworkCore;

namespace Tournamentus.Core.Model
{
    public class TournamentusDb : DbContext
    {
        public TournamentusDb(DbContextOptions optionsBuilder) : base(optionsBuilder)
        {
        }

        public DbSet<Match> Matchs { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Playoff> Playoffs { get; set; }
        public DbSet<PredictScore> PredictScores { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Timezone> Timezones { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<TournamentTeam> TournamentTeams { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<UserClaim> UserClaims { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<UserPrediction> UserPredictions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>()
               .HasOne(m => m.HomeTeam)
               .WithMany(tt => tt.HomeMatches)
               .HasForeignKey(m => m.HomeTeamId);

            modelBuilder.Entity<Match>()
               .HasOne(m => m.GuestTeam)
               .WithMany(tt => tt.AwayMatches)
               .HasForeignKey(m => m.GuestTeamId);

            modelBuilder.Entity<TournamentUser>()
                .HasKey(tu => new { tu.TournamentId, tu.UserId });

            modelBuilder.Entity<TournamentUser>()
                .HasOne(tu => tu.Tournament)
                .WithMany(t => t.TournamentUsers)
                .HasForeignKey(tu => tu.TournamentId);

            modelBuilder.Entity<TournamentUser>()
                .HasOne(tu => tu.User)
                .WithMany(r => r.TournamentUsers)
                .HasForeignKey(tu => tu.UserId);

            modelBuilder.Entity<UserLogin>()
                .HasKey(ul => new { ul.UserId, ul.ProviderKey, ul.LoginProvider });

            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);
            

            //  Not supported in 
            //modelBuilder.Entity<Role>()
            //    .HasMany(t => t.Users)
            //    .WithMany(t => t.Roles);
            //modelBuilder.Entity<Tournament>()
            //    .HasMany(t => t.Users)
            //    .WithMany(t => t.Tournaments);
        }
    }
}
