using ErtsModel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ErtsModel.Configuration.Entities {
    class GameConfiguration : IEntityTypeConfiguration<Game> {
        private const string _winnerTeamId = "WinnerTeamId";
        internal const string MatchId = "MatchId";
        public void Configure(EntityTypeBuilder<Game> builder) {
            builder.HasComment("Game");

            builder.HasKey(x => x.Id);
            builder.Property(b => b.Id).HasComment("Id").ValueGeneratedOnAdd();

            builder.Property(b => b.StartTime).HasComment("Start time");
            builder.Property(b => b.EndTime).HasComment("End time");
            builder.HasOne(a => a.Winner)
               .WithMany()
               .HasForeignKey(_winnerTeamId);
            builder.Property(b => b.ApiId).HasComment("ApiId");
        }
    }
}
