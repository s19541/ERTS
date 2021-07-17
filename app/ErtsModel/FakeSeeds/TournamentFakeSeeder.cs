using ErtsModel.Entities;
using ErtsModel.Entities.Lol;
using ErtsModel.FakeSeeds.Factories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ErtsModel.FakeSeeds
{
    class TournamentFakeSeeder : FakeSeederBase<Tournament>
    {
        private readonly List<League> leagues;
        private readonly List<Team> teams;
        private readonly List<LolChampion> lolChampions;
        private readonly List<LolSpell> lolSpells;
        private readonly List<LolItem> lolItems;
        private readonly Random random;
        private readonly DbSet<TournamentTeam> dbSetTournamentTeam;
        private readonly DbSet<Series> dbSetSeries;
        private readonly DbSet<LolGamePlayer> dbSetLolGamePlayer;
        private readonly DbSet<LolGameTeam> dbSetLolGameTeam;
        private readonly DbSet<LolGamePlayerItem> dbSetLolGamePlayerItem;

        public TournamentFakeSeeder(List<League> leagues, List<Team> teams, List<LolChampion> lolChampions, List<LolSpell> lolSpells, List<LolItem> lolItems, DbSet<Tournament> dbSet, DbSet<TournamentTeam> dbSetTournamentTeam, DbSet<Series> dbSetSeries, DbSet<LolGamePlayer> dbSetLolGamePlayer, DbSet<LolGameTeam> dbSetLolGameTeam, DbSet<LolGamePlayerItem> dbSetLolGamePlayerItem) : base(dbSet)
        {
            this.leagues = leagues;
            this.teams = teams;
            this.lolChampions = lolChampions;
            this.lolSpells = lolSpells;
            this.lolItems = lolItems;
            this.dbSetTournamentTeam = dbSetTournamentTeam;
            this.dbSetSeries = dbSetSeries;
            this.dbSetLolGamePlayer = dbSetLolGamePlayer;
            this.dbSetLolGameTeam = dbSetLolGameTeam;
            this.dbSetLolGamePlayerItem = dbSetLolGamePlayerItem;
            random = new Random();
        }

        protected override IEnumerable<Tournament> Seed()
        {
            for (int i = 0; i < 100; i++)
            {
                var league = leagues[random.Next(1, leagues.Count)];
                var tournament = FakeTournamentFactory.Create(league);
                var seriesNumber = random.Next(1, 18);
                var tournamentTeams = new List<TournamentTeam>();
                var seriesList = new List<Series>();
                for (int j = 0; j < 10; j++)
                {
                    tournamentTeams.Add(new TournamentTeam
                    {
                        Team = teams[random.Next(1, teams.Count)],
                        Tournament = tournament,
                        SeriesPlayed = 0,
                        SeriesWon = 0,
                        SeriesLost = 0,
                        GamesPlayed = 0,
                        GamesWon = 0,
                        GamesLost = 0
                    });
                }
                for (int j = 0; j < tournamentTeams.Count; j++)
                {
                    for (int k = tournamentTeams[j].SeriesPlayed; k < seriesNumber; k++)
                    {
                        var rnd = new Random();
                        var opponent = tournamentTeams.Where(c => !c.Equals(tournamentTeams[j]))
                                          .OrderBy(x => rnd.Next())
                                          .First();
                        var series = FakeSeriesFactory.Create(tournamentTeams[j].Team, opponent.Team, tournament);
                        seriesList.Add(series);
                        dbSetSeries.Add(series);
                        tournamentTeams[j].SeriesPlayed++;
                        opponent.SeriesPlayed++;
                        var opponentWonGames = 0;
                        var teamWonGames = 0;
                        foreach (Game game in series.Games)
                        {
                            tournamentTeams[j].GamesPlayed++;
                            opponent.GamesPlayed++;
                            if (game.Winner.Equals(opponent.Team))
                            {
                                opponentWonGames++;
                            }
                            else
                            {
                                teamWonGames++;
                            }
                        }
                        opponent.GamesWon += opponentWonGames;
                        opponent.GamesLost += teamWonGames;
                        tournamentTeams[j].GamesWon += teamWonGames;
                        tournamentTeams[j].GamesLost += opponentWonGames;
                        if (opponentWonGames > teamWonGames)
                        {
                            opponent.SeriesWon++;
                            tournamentTeams[j].SeriesLost++;
                        }
                        else if (teamWonGames > opponentWonGames)
                        {
                            opponent.SeriesLost++;
                            tournamentTeams[j].SeriesWon++;
                        }
                        for (var l = 0; l < tournamentTeams.Count; l++)
                        {
                            if (tournamentTeams[l].Team.Equals(opponent))
                                tournamentTeams[l] = opponent;
                        }
                    }
                }
                for (int j = 0; j < tournamentTeams.Count; j++)
                {
                    dbSetTournamentTeam.Add(tournamentTeams[j]);
                }
                foreach(var series in seriesList)
                {
                    foreach(var game in series.Games)
                    {
                        dbSetLolGameTeam.Add(FakeLolGameTeamFactory.Create(series.BlueTeam, game, Enums.LolColor.blue, lolChampions));
                        dbSetLolGameTeam.Add(FakeLolGameTeamFactory.Create(series.RedTeam, game, Enums.LolColor.red, lolChampions));
                        var roles = new List<Enums.LolRole>();
                        roles.Add(Enums.LolRole.top);
                        roles.Add(Enums.LolRole.jun);
                        roles.Add(Enums.LolRole.mid);
                        roles.Add(Enums.LolRole.adc);
                        roles.Add(Enums.LolRole.sup);
                        for (var j = 0; j < series.BlueTeam.Players.Count; j++)
                        {
                            var lolGamePlayer = FakeLolGamePlayerFactory.Create(series.BlueTeam.Players.ToArray()[j], game, roles[j % 5], lolChampions, lolSpells);
                            dbSetLolGamePlayer.Add(lolGamePlayer);
                            for(var k = 0; k < random.Next(0,6); k++)
                                dbSetLolGamePlayerItem.Add(FakeGamePlayerItemFactory.Create(lolGamePlayer, lolItems[random.Next(1, lolItems.Count)]));
                        }
                        for (var j = 0; j < series.RedTeam.Players.Count; j++)
                        {
                            dbSetLolGamePlayer.Add(FakeLolGamePlayerFactory.Create(series.RedTeam.Players.ToArray()[j], game, roles[j % 5], lolChampions, lolSpells));
                        }
                    }
                }
                dbSet.Add(tournament);
                yield return tournament;
            }
        }
    }
}