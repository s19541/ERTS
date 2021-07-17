using ErtsModel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ErtsModel.Configuration.Entities
{
    class SeriesConfiguration : IEntityTypeConfiguration<Series>
    {
        private const string _blueTeamId = "BlueTeamId";
        private const string _redTeamId = "RedTeamId";
        private const string _tournamentId = "tournamentId";
        public void Configure(EntityTypeBuilder<Series> builder)
        {
            builder.HasComment("Lol game stats");

            builder.HasKey(x => x.Id);
            builder.Property(b => b.Id).HasComment("Id").ValueGeneratedOnAdd();

            builder.Property(b => b.StartTime).HasComment("Start time");
            builder.Property(b => b.EndTime).HasComment("End time");

            builder.Property(b => b.StreamUrl).HasComment("Stream url");

            builder.HasOne(a => a.BlueTeam)
                .WithMany()
                .HasForeignKey(_blueTeamId);

            builder.HasOne(a => a.RedTeam)
                .WithMany()
                .HasForeignKey(_redTeamId);
            builder.HasOne(a => a.Tournament)
                .WithMany()
                .HasForeignKey(_tournamentId);
            builder.HasMany(a => a.Games)
                .WithOne()
                .HasForeignKey(GameConfiguration.SeriesId);
        }
    }
}
