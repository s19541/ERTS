using ErtsModel.Entities;
using ErtsModel.Entities.Lol;
using ErtsModel.FakeSeeds.Factories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ErtsModel.FakeSeeds {
    class TournamentFakeSeeder : FakeSeederBase<Tournament> {
        private readonly List<Serie> series;
        private readonly List<Team> teams;
        private readonly List<LolChampion> lolChampions;
        private readonly List<LolSpell> lolSpells;
        private readonly List<LolItem> lolItems;
        private readonly Random random;
        private readonly DbSet<LolTournamentTeam> dbSetLolTournamentTeam;
        private readonly DbSet<LolTournamentPlayer> dbSetLolTournamentPlayer;
        private readonly DbSet<Match> dbSetMatches;
        private readonly DbSet<LolGamePlayer> dbSetLolGamePlayer;
        private readonly DbSet<LolGameTeam> dbSetLolGameTeam;
        private readonly DbSet<LolGamePlayerItem> dbSetLolGamePlayerItem;

        public TournamentFakeSeeder(List<Serie> series, List<Team> teams, List<LolChampion> lolChampions, List<LolSpell> lolSpells, List<LolItem> lolItems, DbSet<Tournament> dbSetTournament, DbSet<LolTournamentTeam> dbSetLolTournamentTeam, DbSet<LolTournamentPlayer> dbSetLolTournamentPlayer, DbSet<Match> dbSetMatches, DbSet<LolGamePlayer> dbSetLolGamePlayer, DbSet<LolGameTeam> dbSetLolGameTeam, DbSet<LolGamePlayerItem> dbSetLolGamePlayerItem) : base(dbSetTournament) {
            this.series = series;
            this.teams = teams;
            this.lolChampions = lolChampions;
            this.lolSpells = lolSpells;
            this.lolItems = lolItems;
            this.dbSetLolTournamentTeam = dbSetLolTournamentTeam;
            this.dbSetLolTournamentPlayer = dbSetLolTournamentPlayer;
            this.dbSetMatches = dbSetMatches;
            this.dbSetLolGamePlayer = dbSetLolGamePlayer;
            this.dbSetLolGameTeam = dbSetLolGameTeam;
            this.dbSetLolGamePlayerItem = dbSetLolGamePlayerItem;
            random = new Random();
        }

        protected override IEnumerable<Tournament> Seed() {
            for (int i = 0; i < 100; i++) {
                var serie = series[random.Next(1, series.Count)];
                var tournament = FakeTournamentFactory.Create(serie);
                var matchNumber = random.Next(1, 18);
                var tournamentTeams = new List<LolTournamentTeam>();
                var tournamentPlayers = new List<LolTournamentPlayer>();
                var matchList = new List<Match>();
                for (int j = 0; j < 10; j++) {
                    tournamentTeams.Add(FakeLolTournamentTeamFactory.Create(teams[random.Next(1, teams.Count)], tournament, lolChampions));
                }
                for (int j = 0; j < tournamentTeams.Count; j++) {
                    for (int k = tournamentTeams[j].MatchesWon + tournamentTeams[j].MatchesLost; k < matchNumber; k++) {
                        var rnd = new Random();
                        var opponent = tournamentTeams.Where(c => !c.Equals(tournamentTeams[j]))
                                          .OrderBy(x => rnd.Next())
                                          .First();
                        var matches = FakeMatchesFactory.Create(tournamentTeams[j].Team, opponent.Team, tournament);
                        matchList.Add(matches);
                        dbSetMatches.Add(matches);
                        var opponentWonGames = 0;
                        var teamWonGames = 0;
                        foreach (Game game in matches.Games) {
                            if (game.Winner.Equals(opponent.Team)) {
                                opponentWonGames++;
                            } else {
                                teamWonGames++;
                            }
                        }
                        opponent.GamesWon += opponentWonGames;
                        opponent.GamesLost += teamWonGames;
                        tournamentTeams[j].GamesWon += teamWonGames;
                        tournamentTeams[j].GamesLost += opponentWonGames;
                        if (opponentWonGames > teamWonGames) {
                            opponent.MatchesWon++;
                            tournamentTeams[j].MatchesLost++;
                        } else if (teamWonGames > opponentWonGames) {
                            opponent.MatchesLost++;
                            tournamentTeams[j].MatchesWon++;
                        }
                        for (var l = 0; l < tournamentTeams.Count; l++) {
                            if (tournamentTeams[l].Team.Equals(opponent))
                                tournamentTeams[l] = opponent;
                        }
                    }
                }
                for (int j = 0; j < tournamentTeams.Count; j++) {
                    dbSetLolTournamentTeam.Add(tournamentTeams[j]);
                    foreach (Player player in tournamentTeams[j].Team.Players)
                        tournamentPlayers.Add(FakeLolTournamentPlayerFactory.Create(player, tournamentTeams[j].Tournament, lolChampions));
                }
                for (int j = 0; j < tournamentPlayers.Count; j++) {
                    dbSetLolTournamentPlayer.Add(tournamentPlayers[j]);
                }
                foreach (var match in matchList) {
                    foreach (var game in match.Games) {
                        dbSetLolGameTeam.Add(FakeLolGameTeamFactory.Create(match.Team1, game, Enums.LolColor.blue, lolChampions));
                        dbSetLolGameTeam.Add(FakeLolGameTeamFactory.Create(match.Team2, game, Enums.LolColor.red, lolChampions));
                        var roles = new List<Enums.LolRole>();
                        roles.Add(Enums.LolRole.top);
                        roles.Add(Enums.LolRole.jun);
                        roles.Add(Enums.LolRole.mid);
                        roles.Add(Enums.LolRole.adc);
                        roles.Add(Enums.LolRole.sup);
                        for (var j = 0; j < match.Team1.Players.Count; j++) {
                            var lolGamePlayer = FakeLolGamePlayerFactory.Create(match.Team1.Players.ToArray()[j], game, roles[j % 5], lolChampions, lolSpells);
                            dbSetLolGamePlayer.Add(lolGamePlayer);
                            for (var k = 0; k < random.Next(0, 8); k++)
                                dbSetLolGamePlayerItem.Add(FakeGamePlayerItemFactory.Create(lolGamePlayer, lolItems[random.Next(1, lolItems.Count)]));
                        }
                        for (var j = 0; j < match.Team2.Players.Count; j++) {
                            dbSetLolGamePlayer.Add(FakeLolGamePlayerFactory.Create(match.Team2.Players.ToArray()[j], game, roles[j % 5], lolChampions, lolSpells));
                        }
                    }
                }
                dbSet.Add(tournament);
                yield return tournament;
            }
        }
    }
}