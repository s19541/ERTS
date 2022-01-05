using ErtsModel.Entities.Lol;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ErtsModel.Configuration.Entities {
    class LolGameTeamConfiguration : IEntityTypeConfiguration<LolGameTeam> {
        private const string _teamId = "TeamId";
        private const string _gameId = "GameId";
        private const string _ban1Id = "Ban1Id";
        private const string _ban2Id = "Ban2Id";
        private const string _ban3Id = "Ban3Id";
        private const string _ban4Id = "Ban4Id";
        private const string _ban5Id = "Ban5Id";
        public void Configure(EntityTypeBuilder<LolGameTeam> builder) {
            builder.HasComment("Team stats in game");

            builder.HasKey(x => x.Id);
            builder.Property(b => b.Id).HasComment("Id").ValueGeneratedOnAdd();

            builder.HasOne(a => a.Team)
               .WithMany()
               .HasForeignKey(_teamId);
            builder.HasOne(a => a.Game)
               .WithMany()
               .HasForeignKey(_gameId);

            builder.Property(b => b.BaronKilled).HasComment("Baron killed");
            builder.Property(b => b.MountainDrakeKilled).HasComment("Mountain drake killed");
            builder.Property(b => b.InfernalDrakeKilled).HasComment("Infernal drake killed");
            builder.Property(b => b.OceanDrakeKilled).HasComment("Ocean drake killed");
            builder.Property(b => b.CloudDrakeKilled).HasComment("Cloud drake killed");
            builder.Property(b => b.ElderDrakeKilled).HasComment("Elder drake killed");
            builder.Property(b => b.HeraldKilled).HasComment("Herald killed");
            builder.Property(b => b.GoldEarned).HasComment("Gold earned");
            builder.Property(b => b.Kills).HasComment("Kills");
            builder.Property(b => b.TurretDestroyed).HasComment("Turret destroyed");
            builder.Property(b => b.TurretDestroyed).HasComment("Inhibitor destroyed");
            builder.Property(b => b.Color).HasComment("Color");

            builder.Property(b => b.FirstBaron).HasComment("First baron");
            builder.Property(b => b.FirstBlood).HasComment("First blood");
            builder.Property(b => b.MountainDrakeKilled).HasComment("First dragon");
            builder.Property(b => b.MountainDrakeKilled).HasComment("First turret");
            builder.Property(b => b.MountainDrakeKilled).HasComment("First inhibitor");

            builder.HasOne(a => a.Ban1)
               .WithMany()
               .HasForeignKey(_ban1Id);
            builder.HasOne(a => a.Ban2)
               .WithMany()
               .HasForeignKey(_ban2Id);
            builder.HasOne(a => a.Ban3)
               .WithMany()
               .HasForeignKey(_ban3Id);
            builder.HasOne(a => a.Ban4)
               .WithMany()
               .HasForeignKey(_ban4Id);
            builder.HasOne(a => a.Ban5)
               .WithMany()
               .HasForeignKey(_ban5Id);
        }
    }
}
