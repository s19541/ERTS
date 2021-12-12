using ErtsModel._Infrastructure.Converters;
using ErtsModel.Entities;
using ErtsModel.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ErtsModel.Configuration.Entities {
    class TeamConfiguration : IEntityTypeConfiguration<Team> {
        public void Configure(EntityTypeBuilder<Team> builder) {
            builder.HasComment("Team");

            builder.HasKey(x => x.Id);
            builder.Property(b => b.Id).HasComment("Id").ValueGeneratedOnAdd();
            builder.Property(b => b.Name).HasComment("Name").IsRequired();
            builder.Property(b => b.Acronym).HasComment("Acronym");
            builder.Property(b => b.ImageUrl).HasComment("Image url");

            builder.Property(b => b.GameType).HasComment("Game type").HasConversion(EnumValueConverterFactory.Create<GameType>());

            builder.HasMany(a => a.Players)
                .WithOne()
                .HasForeignKey(PlayerConfiguration.TeamId);

            builder.Property(b => b.ApiId).HasComment("ApiId");
        }
    }
}
