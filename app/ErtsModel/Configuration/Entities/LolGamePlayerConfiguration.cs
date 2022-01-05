using ErtsModel.Entities.Lol;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ErtsModel.Configuration.Entities {
    class LolGamePlayerConfiguration : IEntityTypeConfiguration<LolGamePlayer> {
        private const string _playerId = "PlayerId";
        private const string _gameId = "GameId";
        private const string _championId = "ChampionId";
        private const string _spell1Id = "Spell1Id";
        private const string _spell2Id = "Spell2Id";
        public void Configure(EntityTypeBuilder<LolGamePlayer> builder) {
            builder.HasComment("Player stats in game");

            builder.HasKey(x => x.Id);
            builder.Property(b => b.Id).HasComment("Id").ValueGeneratedOnAdd();

            builder.HasOne(a => a.Player)
              .WithMany()
              .HasForeignKey(_playerId);
            builder.HasOne(a => a.Game)
               .WithMany()
               .HasForeignKey(_gameId);
            builder.HasOne(a => a.Champion)
               .WithMany()
               .HasForeignKey(_championId);

            builder.Property(b => b.Role).HasComment("Role");
            builder.Property(b => b.Kills).HasComment("Kills");
            builder.Property(b => b.Deaths).HasComment("Deaths");
            builder.Property(b => b.Assists).HasComment("Assists");
            builder.Property(b => b.GoldEarned).HasComment("Gold earned");
            builder.Property(b => b.GoldSpent).HasComment("Gold spent");
            builder.Property(b => b.LargestCriticalStrike).HasComment("Largest critical strike");
            builder.Property(b => b.LargestKillingSpree).HasComment("Largest killing spree");
            builder.Property(b => b.LargestMultiKill).HasComment("Largest multi kill");
            builder.Property(b => b.Level).HasComment("Level");
            builder.Property(b => b.MagicDamageDealt).HasComment("Magic damage dealt");
            builder.Property(b => b.MagicDamageDealtToChamps).HasComment("Magic damage dealt to champs");
            builder.Property(b => b.PhysicalDamageDealt).HasComment("Physical damage dealt");
            builder.Property(b => b.PhysicalDamageDealtToChamps).HasComment("Physical damage dealt to champs");
            builder.Property(b => b.TrueDamageDealt).HasComment("True damage dealt");
            builder.Property(b => b.TrueDamageDealtToChamps).HasComment("True damage dealt to champs");
            builder.Property(b => b.DamageDealt).HasComment("Damage dealt");
            builder.Property(b => b.DamageDealtToChamps).HasComment("Damage dealt to champs");
            builder.Property(b => b.DamageTaken).HasComment("Damage taken");
            builder.Property(b => b.TotalHeal).HasComment("Total heal");
            builder.Property(b => b.TotalTimeCrowdControlDealt).HasComment("Total time crowd control dealt");
            builder.Property(b => b.WardsPlaced).HasComment("Wards placed");
            builder.Property(b => b.WardsDestroyed).HasComment("Wards destroyed");
            builder.Property(b => b.TurretsDestroyed).HasComment("Turrets destroyed");
            builder.Property(b => b.InhibitorsDestroyed).HasComment("Inhibitor destroyed");
            builder.Property(b => b.MinionsKilled).HasComment("Minions killed");
            builder.Property(b => b.NeutralMinionsKilled).HasComment("Neutral minions killed");
            builder.Property(b => b.FirstBlood).HasComment("First blood");
            builder.Property(b => b.FirstBloodAssist).HasComment("Total blood assits");

            builder.HasOne(a => a.Spell1)
               .WithMany()
               .HasForeignKey(_spell1Id);
            builder.HasOne(a => a.Spell2)
               .WithMany()
               .HasForeignKey(_spell2Id);

        }
    }
}
