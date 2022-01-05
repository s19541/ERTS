using ErtsModel._Infrastructure.Converters;
using ErtsModel.Entities;
using ErtsModel.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ErtsModel.Configuration.Entities {
    class LeagueConfiguration : IEntityTypeConfiguration<League> {
        public void Configure(EntityTypeBuilder<League> builder) {
            builder.HasComment("League");

            builder.HasKey(x => x.Id);
            builder.Property(b => b.Id).HasComment("Id").ValueGeneratedOnAdd();
            builder.Property(b => b.Name).HasComment("Name").IsRequired();
            builder.Property(b => b.GameType).HasComment("Game type").HasConversion(EnumValueConverterFactory.Create<GameType>());
            builder.Property(b => b.ImageUrl).HasComment("Image url");
            builder.Property(b => b.Url).HasComment("Url");
            builder.Property(b => b.ApiId).HasComment("ApiId");


        }
    }
}
