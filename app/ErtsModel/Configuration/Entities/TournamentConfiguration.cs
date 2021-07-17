using ErtsModel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ErtsModel.Configuration.Entities
{
    class TournamentConfiguration : IEntityTypeConfiguration<Tournament>
    {
        private const string _leagueId = "LeagueId";
        public void Configure(EntityTypeBuilder<Tournament> builder)
        {
            builder.HasComment("Tournament");
            builder.HasKey(x => x.Id);
            builder.Property(b => b.Id).HasComment("Id").ValueGeneratedOnAdd();

            builder.Property(b => b.Name).HasComment("Name").IsRequired();
            builder.Property(b => b.PrizePool).HasComment("Prize pool");

            builder.Property(b => b.StartTime).HasComment("Start time");
            builder.Property(b => b.EndTime).HasComment("End time");
            builder.HasOne(a => a.League)
               .WithMany()
               .HasForeignKey(_leagueId);


        }
    }
}
