using ErtsModel.Entities;
using ErtsModel.FakeSeeds.Factories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ErtsModel.FakeSeeds
{
    class SeriesFakeSeeder : FakeSeederBase<Series>
    {
        private readonly List<Team> teams;
        private readonly List<Tournament> tournaments;
        private readonly Random random;
        public SeriesFakeSeeder(List<Team> teams, List<Tournament> tournaments, DbSet<Series> dbSet) : base(dbSet)
        {
            this.teams = teams;
            this.tournaments = tournaments;
            random = new Random();
        }
        protected override IEnumerable<Series> Seed()
        {
            for (int i = 0; i < 500; i++)
            {
                var team1 = teams[random.Next(1, teams.Count)];
                Team team2;
                do { team2 = teams[random.Next(1, teams.Count)]; }
                while (team1 == team2);

                var tournament = tournaments[random.Next(1, tournaments.Count)];
                var series = FakeSeriesFactory.Create(team1, team2, tournament);
                dbSet.Add(series);
                yield return series;
            }
        }
    }
}
