using ErtsModel.Entities.Lol;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ErtsModel.Configuration.Entities
{
    class LolGameStatsConfiguration : IEntityTypeConfiguration<LolGameStats>
    {
        private const string _blueTeamId = "BlueTeamId";
        private const string _redTeamId = "RedTeamId";
        public void Configure(EntityTypeBuilder<LolGameStats> builder)
        {
            builder.HasComment("Lol game stats");

            builder.HasKey(x => x.Id);
            builder.Property(b => b.Id).HasComment("Id").ValueGeneratedNever();

            builder.Property(b => b.StartTime).HasComment("Start time");
            builder.Property(b => b.EndTime).HasComment("End time");

            builder.HasOne(a => a.BlueTeam)
                .WithMany()
                .HasForeignKey(_blueTeamId);

            builder.HasOne(a => a.RedTeam)
                .WithMany()
                .HasForeignKey(_redTeamId);
        }
    }
}
