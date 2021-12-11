using ErtsModel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ErtsModel.Configuration.Entities {
    class MatchConfiguration : IEntityTypeConfiguration<Match> {
        private const string _Team1Id = "Team1Id";
        private const string _Team2Id = "Team2Id";
        private const string _tournamentId = "tournamentId";
        public void Configure(EntityTypeBuilder<Match> builder) {
            builder.HasComment("Lol game stats");

            builder.HasKey(x => x.Id);
            builder.Property(b => b.Id).HasComment("Id").ValueGeneratedOnAdd();

            builder.Property(b => b.StartTime).HasComment("Start time");
            builder.Property(b => b.EndTime).HasComment("End time");

            builder.Property(b => b.StreamUrl).HasComment("Stream url");

            builder.HasOne(a => a.Team1)
                .WithMany()
                .HasForeignKey(_Team1Id);

            builder.HasOne(a => a.Team2)
                .WithMany()
                .HasForeignKey(_Team2Id);
            builder.HasOne(a => a.Tournament)
                .WithMany()
                .HasForeignKey(_tournamentId);
            builder.HasMany(a => a.Games)
                .WithOne()
                .HasForeignKey(GameConfiguration.MatchId);
            builder.Property(b => b.NumberOfGames).HasComment("Number of games");
            builder.Property(b => b.ApiId).HasComment("ApiId");
        }
    }
}
