using ErtsModel.Entities.Lol;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ErtsModel.Configuration.Entities {
    class LolChampionConfiguration : IEntityTypeConfiguration<LolChampion> {
        public void Configure(EntityTypeBuilder<LolChampion> builder) {
            builder.HasComment("Lol Champion");

            builder.HasKey(x => x.Id);
            builder.Property(b => b.Id).HasComment("Id").ValueGeneratedOnAdd();
            builder.Property(b => b.Name).HasComment("Name").IsRequired();
            builder.Property(b => b.ImageUrl).HasComment("Image url");
        }
    }
}
