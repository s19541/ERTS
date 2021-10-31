using ErtsModel.Configuration.Entities;
using ErtsModel.Entities;
using ErtsModel.Entities.Lol;
using Microsoft.EntityFrameworkCore;

namespace ErtsModel {
    public class ErtsContext : DbContext {
        public ErtsContext(string connectionString) : base(GetDbContextOptionsForMigrations(connectionString)) { }

        private static DbContextOptions GetDbContextOptionsForMigrations(string connectionString) {
            var option = new DbContextOptionsBuilder();
            option.UseNpgsql(connectionString);

            return option.Options;
        }

        public ErtsContext(DbContextOptions options) : base(options) { }

        public DbSet<Player> Players { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<LolItem> LolItems { get; set; }
        public DbSet<LolChampion> LolChampions { get; set; }
        public DbSet<LolSpell> LolSpells { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<LolTournamentTeam> LolTournamentTeams { get; set; }
        public DbSet<LolTournamentPlayer> LolTournamentPlayers { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<LolGamePlayer> LolGamePlayers { get; set; }
        public DbSet<LolGameTeam> LolGameTeams { get; set; }
        public DbSet<LolGamePlayerItem> LolGamePlayerItems { get; set; }
        public DbSet<TournamentTeam> TournamentTeams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new PlayerConfiguration());
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
            modelBuilder.ApplyConfiguration(new MatchConfiguration());
            modelBuilder.ApplyConfiguration(new LolItemConfiguration());
            modelBuilder.ApplyConfiguration(new LolChampionConfiguration());
            modelBuilder.ApplyConfiguration(new LolSpellConfiguration());
            modelBuilder.ApplyConfiguration(new LeagueConfiguration());
            modelBuilder.ApplyConfiguration(new SerieConfiguration());
            modelBuilder.ApplyConfiguration(new TournamentConfiguration());
            modelBuilder.ApplyConfiguration(new LolTournamentTeamConfiguration());
            modelBuilder.ApplyConfiguration(new LolTournamentPlayerConfiguration());
            modelBuilder.ApplyConfiguration(new GameConfiguration());
            modelBuilder.ApplyConfiguration(new LolGamePlayerConfiguration());
            modelBuilder.ApplyConfiguration(new LolGameTeamConfiguration());
            modelBuilder.ApplyConfiguration(new LolGamePlayerItemConfiguration());
            modelBuilder.ApplyConfiguration(new TournamentTeamConfiguration());
        }
    }
}
