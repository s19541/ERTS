using ErtsModel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ErtsModel.Configuration.Entities {
    class PlayerConfiguration : IEntityTypeConfiguration<Player> {
        internal const string TeamId = "TeamId";
        //internal const string CsgoTeamId = "CsgoTeamId";

        public void Configure(EntityTypeBuilder<Player> builder) {
            builder.HasComment("Players");

            builder.HasKey(x => x.Id);
            builder.Property(b => b.Id).HasComment("Id").ValueGeneratedOnAdd();

            builder.Property(b => b.FirstName).HasComment("First Name");
            builder.Property(b => b.LastName).HasComment("Last Name");

            builder.Property(b => b.Nick).HasComment("Nickname").IsRequired();

            builder.Property(b => b.Nationality).HasComment("Nationality");
            builder.Property(b => b.ApiId).HasComment("ApiId");
        }
    }
}
