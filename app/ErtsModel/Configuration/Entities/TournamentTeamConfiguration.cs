using ErtsModel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErtsModel.Configuration.Entities {
    class TournamentTeamConfiguration : IEntityTypeConfiguration<TournamentTeam> {
        private const string _tournamentId = "TournamentId";
        private const string _teamId = "TeamId";
     
        public void Configure(EntityTypeBuilder<TournamentTeam> builder) {
            builder.HasComment("Tournament to team");
            builder.HasKey(x => x.Id);
            builder.Property(b => b.Id).HasComment("Id").ValueGeneratedOnAdd();

            builder.HasOne(a => a.Tournament)
               .WithMany()
               .HasForeignKey(_tournamentId);
            builder.HasOne(a => a.Team)
               .WithMany()
               .HasForeignKey(_teamId);

            builder.Property(b => b.GamesWon).HasComment("GamesWon");
            builder.Property(b => b.GamesLost).HasComment("GamesLost");
            builder.Property(b => b.MatchesWon).HasComment("MatchesWon");
            builder.Property(b => b.MatchesLost).HasComment("MatchesLost");
        }
    }
}
