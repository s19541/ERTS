using ErtsModel.Entities.Lol;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ErtsModel.Configuration.Entities {
    class LolGamePlayerItemConfiguration : IEntityTypeConfiguration<LolGamePlayerItem> {
        private const string _itemId = "ItemId";
        private const string _gamePlayerId = "GamePlayerId";
        public void Configure(EntityTypeBuilder<LolGamePlayerItem> builder) {
            builder.HasComment("items of player in game");

            builder.HasKey(x => x.Id);
            builder.Property(b => b.Id).HasComment("Id").ValueGeneratedOnAdd();

            builder.HasOne(a => a.Item)
               .WithMany()
               .HasForeignKey(_itemId);
            builder.HasOne(a => a.GamePlayer)
               .WithMany()
               .HasForeignKey(_gamePlayerId);
        }
    }
}
