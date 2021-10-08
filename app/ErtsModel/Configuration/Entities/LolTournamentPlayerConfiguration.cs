using ErtsModel.Entities.Lol;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ErtsModel.Configuration.Entities {
    class LolTournamentPlayerConfiguration : IEntityTypeConfiguration<LolTournamentPlayer> {
        private const string _tournamentId = "TournamentId";
        private const string _playerId = "PlayerId";
        private const string _championId1 = "ChampionId1";
        private const string _championId2 = "ChampionId2";
        private const string _championId3 = "ChampionId3";
        public void Configure(EntityTypeBuilder<LolTournamentPlayer> builder) {
            builder.HasComment("Tournament to player");
            builder.HasKey(x => x.Id);
            builder.Property(b => b.Id).HasComment("Id").ValueGeneratedOnAdd();

            builder.HasOne(a => a.Tournament)
               .WithMany()
               .HasForeignKey(_tournamentId);

            builder.HasOne(a => a.Player)
               .WithMany()
               .HasForeignKey(_playerId);

            builder.Property(b => b.AverageKills).HasComment("AverageKills");
            builder.Property(b => b.AverageDeaths).HasComment("AverageDeaths");
            builder.Property(b => b.AverageAssists).HasComment("AverageAssists");
            builder.Property(b => b.AverageMinionsKilled).HasComment("AverageMinionsKilled");
            builder.Property(b => b.MinionsPerMinute).HasComment("MinionsPerMinute");
            builder.Property(b => b.GoldPerMinute).HasComment("GoldPerMinute");
            builder.Property(b => b.KillParticipation).HasComment("KillParticipation");
            builder.Property(b => b.DamageShare).HasComment("DamageShare");
            builder.Property(b => b.KillParticipation).HasComment("KillParticipation");
            builder.Property(b => b.ChampionsPlayed).HasComment("ChampionPlayed");

            builder.HasOne(a => a.FavouriteChampion1)
               .WithMany()
               .HasForeignKey(_championId1);

            builder.HasOne(a => a.FavouriteChampion2)
               .WithMany()
               .HasForeignKey(_championId2);

            builder.HasOne(a => a.FavouriteChampion3)
               .WithMany()
               .HasForeignKey(_championId3);
        }
    }
}
