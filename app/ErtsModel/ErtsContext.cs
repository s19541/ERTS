using ErtsModel.Configuration.Entities;
using ErtsModel.Entities;
using ErtsModel.Entities.Lol;
using Microsoft.EntityFrameworkCore;

namespace ErtsModel
{
    public class ErtsContext : DbContext
    {
        public ErtsContext(string connectionString) : base(GetDbContextOptionsForMigrations(connectionString)) { }

        private static DbContextOptions GetDbContextOptionsForMigrations(string connectionString)
        {
            var option = new DbContextOptionsBuilder();
            option.UseNpgsql(connectionString);

            return option.Options;
        }

        public ErtsContext(DbContextOptions options) : base(options) { }

        public DbSet<Player> Players { get; set; }
        public DbSet<LolGameStats> LolGamesStats { get; set; }
        public DbSet<Team> LolTeams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PlayerConfiguration());
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
            modelBuilder.ApplyConfiguration(new LolGameStatsConfiguration());
        }
    }
}
