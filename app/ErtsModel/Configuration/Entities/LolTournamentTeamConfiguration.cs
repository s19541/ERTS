using ErtsModel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ErtsModel.Configuration.Entities {
    class LolTournamentTeamConfiguration : IEntityTypeConfiguration<LolTournamentTeam> {
        private const string _tournamentId = "TournamentId";
        private const string _teamId = "TeamId";
        private const string _championId1 = "ChampionId1";
        private const string _championId2 = "ChampionId2";
        private const string _championId3 = "ChampionId3";
        private const string _championId4 = "ChampionId4";
        private const string _championId5 = "ChampionId5";
        public void Configure(EntityTypeBuilder<LolTournamentTeam> builder) {


            builder.Property(b => b.AverageKills).HasComment("AverageKills");
            builder.Property(b => b.AverageDeaths).HasComment("AverageDeaths");
            builder.Property(b => b.AverageAssists).HasComment("AverageAssists");
            builder.Property(b => b.AverageGoldEarned).HasComment("AverageGoldEarned");
            builder.Property(b => b.AverageDragonKilled).HasComment("AverageDragonKilled");
            builder.Property(b => b.AverageHeraldKilled).HasComment("AverageHeraldKilled");
            builder.Property(b => b.AverageBaronKilled).HasComment("AverageBaronKilled");
            builder.Property(b => b.AverageTowerDestroyed).HasComment("AverageTowerDestroyed");

            builder.HasOne(a => a.FavouriteChampion1)
               .WithMany()
               .HasForeignKey(_championId1);

            builder.HasOne(a => a.FavouriteChampion2)
               .WithMany()
               .HasForeignKey(_championId2);

            builder.HasOne(a => a.FavouriteChampion3)
               .WithMany()
               .HasForeignKey(_championId3);

            builder.HasOne(a => a.FavouriteChampion4)
              .WithMany()
              .HasForeignKey(_championId4);

            builder.HasOne(a => a.FavouriteChampion5)
              .WithMany()
              .HasForeignKey(_championId5);


        }
    }
}
