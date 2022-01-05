using ErtsModel.Entities.Lol;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ErtsModel.Configuration.Entities {
    class LolItemConfiguration : IEntityTypeConfiguration<LolItem> {
        public void Configure(EntityTypeBuilder<LolItem> builder) {
            builder.HasComment("Lol Item");
            builder.HasKey(x => x.Id);
            builder.Property(b => b.Id).HasComment("Id").ValueGeneratedOnAdd();
            builder.Property(b => b.Name).HasComment("Name").IsRequired();
            builder.Property(b => b.ImageUrl).HasComment("Image url");
            builder.Property(b => b.IsTrinket).HasComment("Is trinket");
        }
    }
}
