using ErtsModel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ErtsModel.Configuration.Entities
{
    class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        internal const string TeamId = "TeamId";
        //internal const string CsgoTeamId = "CsgoTeamId";

        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.HasComment("Players");

            builder.HasKey(x => x.Id);
            builder.Property(b => b.Id).HasComment("Id").ValueGeneratedOnAdd();

            builder.Property(b => b.Name).HasComment("Name");
            builder.Property(b => b.Surname).HasComment("Surname");

            builder.Property(b => b.Nick).HasComment("Nickname").IsRequired();

            builder.Property<long>(TeamId).HasComment("Team ID");
            //builder.Property<long>(CsgoTeamId).HasComment("CS GO team ID");
        }
    }
}
