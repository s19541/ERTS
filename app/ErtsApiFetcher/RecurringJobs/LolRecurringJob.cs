using ErtsApiFetcher._Infrastructure.RecurringJobs;
using ErtsApiFetcher.Fetchers;
using ErtsModel;
using ErtsModel.Entities.Lol;
using Hangfire;
using System;
using System.Linq;

namespace ErtsApiFetcher.RecurringJobs {
    [RecurringJobInfo(typeof(LolRecurringJob), nameof(LolRecurringJob), ErtsCron.OncePerWeek)]
    public class LolRecurringJob : IRecurringJob {
        private readonly ErtsContext context;
        private readonly LolDataFetcher lolDataFetcher;

        public LolRecurringJob(ErtsContext context) {
            this.context = context;
            this.lolDataFetcher = new LolDataFetcher("YCqH-LZuSLFrILAk1bDq2KlXdG85FuTlE4grbo-eqyqZcRVflcM", context);
        }

        [AutomaticRetry(Attempts = 0)]
        public void Job() {
            /*
            context.Database.BeginTransaction();
            FetchAndSaveChampions();
            FetchAndSaveItems();
            FetchAndSaveSpells();
            FetchAndSaveLeagues();
            FetchAndSaveSeries();
            FetchAndSaveTournaments();
            FetchAndSavePlayers();
            FetchAndSaveTeams();
            FetchAndSaveMatches();
            context.Database.CommitTransaction();
            */
            createTournamentTeamStats();
            createTournamentPlayerStats();
        }

        private void FetchAndSaveMatches() {
            var apiMatches = lolDataFetcher.FetchMatches();
            var newMatches = apiMatches.Where(apiMatches => !context.Matches.Any(contextMatche => contextMatche.ApiId == apiMatches.ApiId));
            context.Matches.AddRange(newMatches);

            var random = new Random();
            var champions = context.LolChampions.ToArray();
            var spells = context.LolSpells.ToArray();
            var items = context.LolItems.Where(item => !item.IsTrinket).ToArray();
            var trinkets = context.LolItems.Where(item => item.IsTrinket).ToArray();

            foreach (var newMatch in newMatches) {
                var newGames = newMatch.Games.Where(apiGame => !context.Games.Any(contextGame => contextGame.ApiId == apiGame.ApiId));

                foreach (var newGame in newGames) {
                    if (newGame.EndTime != null) {
                        context.LolGameTeam.Add(new LolGameTeam() {
                            Team = newMatch.Team1,
                            Game = newGame,
                            Color = ErtsModel.Enums.LolColor.blue,
                            Ban1 = champions[random.Next(champions.Count())],
                            Ban2 = champions[random.Next(champions.Count())],
                            Ban3 = champions[random.Next(champions.Count())],
                            Ban4 = champions[random.Next(champions.Count())],
                            Ban5 = champions[random.Next(champions.Count())]
                        });

                        context.LolGameTeam.Add(new LolGameTeam() {
                            Team = newMatch.Team2,
                            Game = newGame,
                            Color = ErtsModel.Enums.LolColor.red,
                            Ban1 = champions[random.Next(champions.Count())],
                            Ban2 = champions[random.Next(champions.Count())],
                            Ban3 = champions[random.Next(champions.Count())],
                            Ban4 = champions[random.Next(champions.Count())],
                            Ban5 = champions[random.Next(champions.Count())]
                        });

                        foreach (var player in newMatch.Team1.Players.Union(newMatch.Team2.Players)) {
                            var lolGamePlayer = new LolGamePlayer() {
                                Player = player,
                                Game = newGame,
                                Role = ErtsModel.Enums.LolRole.mid,
                                Champion = champions[random.Next(champions.Count())],
                                Spell1 = spells[random.Next(spells.Count())],
                                Spell2 = spells[random.Next(spells.Count())]
                            };
                            context.LolGamePlayers.Add(lolGamePlayer);

                            context.LolGamePlayerItems.Add(new LolGamePlayerItem() {
                                GamePlayer = lolGamePlayer,
                                Item = trinkets[random.Next(trinkets.Count())]
                            });
                            for (int i = 0; i < random.Next(7); i++) {
                                context.LolGamePlayerItems.Add(new LolGamePlayerItem() {
                                    GamePlayer = lolGamePlayer,
                                    Item = items[random.Next(items.Count())]
                                });
                            }
                        }
                    }

                }
            }

            context.SaveChanges();
        }

        private void FetchAndSaveTeams() {
            var apiTeams = lolDataFetcher.FetchTeams();
            var newTeams = apiTeams.Where(apiTeam => !context.Players.Any(contextTeam => contextTeam.ApiId == apiTeam.ApiId));
            context.Teams.AddRange(newTeams);

            context.SaveChanges();
        }

        private void FetchAndSavePlayers() {
            var apiPlayers = lolDataFetcher.FetchPlayers();
            var newPlayers = apiPlayers.Where(apiPlayer => !context.Players.Any(contextPlayer => contextPlayer.ApiId == apiPlayer.ApiId));
            context.Players.AddRange(newPlayers);

            context.SaveChanges();
        }

        private void FetchAndSaveTournaments() {
            var apiTournaments = lolDataFetcher.FetchTournaments();
            var newTournaments = apiTournaments.Where(apiTournament => !context.Tournaments.Any(contextTournament => contextTournament.ApiId == apiTournament.ApiId));
            context.Tournaments.AddRange(newTournaments);

            context.SaveChanges();
        }

        private void FetchAndSaveSeries() {
            var apiSeries = lolDataFetcher.FetchSeries();
            var newSeries = apiSeries.Where(apiSerie => !context.Series.Any(contextSerie => contextSerie.ApiId == apiSerie.ApiId));
            context.Series.AddRange(newSeries);

            context.SaveChanges();
        }

        private void FetchAndSaveLeagues() {
            var apiLeagues = lolDataFetcher.FetchLeagues();
            var newLeagues = apiLeagues.Where(apiLeague => !context.Leagues.Any(contextLeague => contextLeague.ApiId == apiLeague.ApiId));
            context.Leagues.AddRange(newLeagues);

            context.SaveChanges();
        }

        private void FetchAndSaveSpells() {
            var apiSpells = lolDataFetcher.FetchSpells();
            var newSpells = apiSpells.Where(apiSpell => !context.LolSpells.Any(contextSpell => contextSpell.Name == apiSpell.Name));
            context.AddRange(newSpells);

            context.SaveChanges();
        }

        private void FetchAndSaveItems() {
            var apiItems = lolDataFetcher.FetchItems();
            var newItems = apiItems.Where(apiItem => !context.LolItems.Any(contextItem => contextItem.Name == apiItem.Name));
            context.AddRange(newItems);

            context.SaveChanges();
        }

        private void FetchAndSaveChampions() {
            var apiChampions = lolDataFetcher.FetchChampions();
            var newChampions = apiChampions.Where(apiChampion => !context.LolChampions.Any(contextChampion => contextChampion.Name == apiChampion.Name));
            context.AddRange(newChampions);

            context.SaveChanges();
        }

        private void createTournamentTeamStats() {
            context.LolTournamentTeams.RemoveRange(context.LolTournamentTeams);
            context.SaveChanges();
            foreach (var tournament in context.Tournaments.ToArray()) {

                var teams = context.Matches.Where(contextMatch => contextMatch.Tournament == tournament).Select(contextMatch => contextMatch.Team1).ToArray().Union(context.Matches.Where(contextMatch => contextMatch.Tournament == tournament).Select(contextMatch => contextMatch.Team2).ToArray()).Distinct();

                foreach (var team in teams) {
                    var gamesLost = 0;
                    var gamesWon = 0;
                    var matchesWon = 0;
                    var matchesLost = 0;
                    var numberOfGames = 0;
                    var kills = 0;
                    var deaths = 0;
                    var assists = 0;
                    var goldEarned = 0;
                    var dragonKilled = 0;
                    var heraldKilled = 0;
                    var baronKilled = 0;
                    var towerDestroyed = 0;
                    var matches = context.Matches.Where(contextMatch => contextMatch.Tournament == tournament && contextMatch.EndTime != null && (contextMatch.Team1 == team || contextMatch.Team2 == team)).ToArray();
                    foreach (var match in matches) {
                        var matchGamesWon = 0;
                        var matchGamesLost = 0;
                        foreach (var game in match.Games) {
                            numberOfGames++;
                            if (game.Winner == team)
                                matchGamesWon++;
                            else
                                matchGamesLost++;

                            foreach (var gameTeam in context.LolGameTeam.Where(contextGameTeam => contextGameTeam.Game == game && contextGameTeam.Team == team)) {
                                goldEarned += gameTeam.GoldEarned;
                                dragonKilled += gameTeam.CloudDrakeKilled;
                                dragonKilled += gameTeam.MountainDrakeKilled;
                                dragonKilled += gameTeam.InfernalDrakeKilled;
                                dragonKilled += gameTeam.OceanDrakeKilled;
                                dragonKilled += gameTeam.ElderDrakeKilled;
                                heraldKilled += gameTeam.HeraldKilled;
                                baronKilled += gameTeam.HeraldKilled;
                                towerDestroyed += gameTeam.TurretDestroyed;
                            }
                            gamesLost += matchGamesLost;
                            gamesWon += matchGamesWon;
                            if (matchGamesWon > matchGamesLost)
                                matchesWon++;
                            else if (matchGamesLost > matchGamesWon)
                                matchesLost++;
                            foreach (var gamePlayer in context.LolGamePlayers.Where(contextGamePlayer => contextGamePlayer.Game == game && team.Players.Contains(contextGamePlayer.Player))) {
                                kills += gamePlayer.Kills;
                                assists += gamePlayer.Assists;
                                deaths += gamePlayer.Deaths;
                            }
                        }
                    }
                    var gamePlayers = context.LolGamePlayers.Where(contextGamePlayer => context.Matches.Where(contextMatch => contextMatch.Games.Contains(contextGamePlayer.Game)).FirstOrDefault().Tournament == tournament && team.Players.Contains(contextGamePlayer.Player)).ToArray();
                    var firstRecentChampion = gamePlayers.Select(o => o.Champion).GroupBy(o => o).Select(o => new { Champion = o.Key, Count = o.Count() }).OrderByDescending(o => o.Count).FirstOrDefault()?.Champion;
                    var secondRecentChampion = gamePlayers.Where(o => o.Champion != firstRecentChampion).Select(o => o.Champion).GroupBy(o => o).Select(o => new { Champion = o.Key, Count = o.Count() }).OrderByDescending(o => o.Count).FirstOrDefault()?.Champion;
                    var thirdRecentChampion = gamePlayers.Where(o => o.Champion != firstRecentChampion && o.Champion != secondRecentChampion).Select(o => o.Champion).GroupBy(o => o).Select(o => new { Champion = o.Key, Count = o.Count() }).OrderByDescending(o => o.Count).FirstOrDefault()?.Champion;
                    var fourthRecentChampion = gamePlayers.Where(o => o.Champion != firstRecentChampion && o.Champion != secondRecentChampion && o.Champion != thirdRecentChampion).Select(o => o.Champion).GroupBy(o => o).Select(o => new { Champion = o.Key, Count = o.Count() }).OrderByDescending(o => o.Count).FirstOrDefault()?.Champion;
                    var fivethRecentChampion = gamePlayers.Where(o => o.Champion != firstRecentChampion && o.Champion != secondRecentChampion && o.Champion != thirdRecentChampion && o.Champion != fourthRecentChampion).Select(o => o.Champion).GroupBy(o => o).Select(o => new { Champion = o.Key, Count = o.Count() }).OrderByDescending(o => o.Count).FirstOrDefault()?.Champion;

                    context.LolTournamentTeams.Add(new ErtsModel.Entities.LolTournamentTeam() {
                        Tournament = tournament,
                        Team = team,
                        GamesLost = gamesLost,
                        GamesWon = gamesWon,
                        MatchesWon = matchesWon,
                        MatchesLost = matchesLost,
                        AverageKills = numberOfGames != 0 ? kills / numberOfGames : 0,
                        AverageDeaths = numberOfGames != 0 ? deaths / numberOfGames : 0,
                        AverageAssists = numberOfGames != 0 ? assists / numberOfGames : 0,
                        AverageGoldEarned = numberOfGames != 0 ? goldEarned / numberOfGames : 0,
                        AverageBaronKilled = numberOfGames != 0 ? baronKilled / numberOfGames : 0,
                        AverageDragonKilled = numberOfGames != 0 ? dragonKilled / numberOfGames : 0,
                        AverageHeraldKilled = numberOfGames != 0 ? heraldKilled / numberOfGames : 0,
                        AverageTowerDestroyed = numberOfGames != 0 ? towerDestroyed / numberOfGames : 0,
                        FavouriteChampion1 = firstRecentChampion,
                        FavouriteChampion2 = secondRecentChampion,
                        FavouriteChampion3 = thirdRecentChampion,
                        FavouriteChampion4 = fourthRecentChampion,
                        FavouriteChampion5 = fivethRecentChampion
                    });
                }
            }


            context.SaveChanges();

        }

        private void createTournamentPlayerStats() {
            context.LolTournamentPlayers.RemoveRange(context.LolTournamentPlayers);
            context.SaveChanges();

            foreach (var tournament in context.Tournaments.Where(contextTournament => contextTournament.Serie.League.GameType == ErtsModel.Enums.GameType.lol).ToArray()) {
                var teams = context.Matches.Where(contextMatch => contextMatch.Tournament == tournament).Select(contextMatch => contextMatch.Team1).ToArray().Union(context.Matches.Where(contextMatch => contextMatch.Tournament == tournament).Select(contextMatch => contextMatch.Team2).ToArray()).Distinct();
                foreach (var team in teams) {
                    foreach (var player in team.Players) {
                        var assists = 0;
                        var kills = 0;
                        var teamKills = 0;
                        var deaths = 0;
                        var minionsKilled = 0;
                        var goldEarned = 0;
                        var numberOfGames = 0;
                        var totalTimeInMInutes = 0.0;
                        var damage = 0;
                        var teamDamage = 0;
                        var matches = context.Matches.Where(contextMatch => contextMatch.Tournament == tournament && contextMatch.EndTime != null && (contextMatch.Team1 == team || contextMatch.Team2 == team)).ToArray();
                        foreach (var match in matches) {
                            foreach (var game in match.Games) {
                                teamKills += context.LolGamePlayers.Where(o => o.Game == game).Where(o => team.Players.Contains(o.Player)).Select(o => o.Kills).Sum();
                                teamDamage += context.LolGamePlayers.Where(o => o.Game == game).Where(o => team.Players.Contains(o.Player)).Select(o => o.DamageDealtToChamps).Sum();
                                numberOfGames++;
                                var gamePlayers = context.LolGamePlayers.Where(gamePlayerContext => gamePlayerContext.Game == game && gamePlayerContext.Player == player).ToArray();
                                totalTimeInMInutes += (game.EndTime - game.StartTime).TotalMinutes;
                                foreach (var gamePlayer in gamePlayers) {
                                    assists += gamePlayer.Assists;
                                    kills += gamePlayer.Kills;
                                    deaths += gamePlayer.Deaths;
                                    damage += gamePlayer.DamageDealtToChamps;
                                    minionsKilled += gamePlayer.MinionsKilled;
                                    goldEarned += gamePlayer.GoldEarned;
                                }
                            }
                        }

                        var gameStats = context.LolGamePlayers.Where(contextGamePlayer => context.Matches.Where(contextMatch => contextMatch.Games.Contains(contextGamePlayer.Game)).FirstOrDefault().Tournament == tournament && contextGamePlayer.Player == player).ToArray();
                        int championsPlayed = gameStats.Select(o => o.Champion).Distinct().Count();
                        var firstRecentChampion = gameStats.Select(o => o.Champion).GroupBy(o => o).Select(o => new { Champion = o.Key, Count = o.Count() }).OrderByDescending(o => o.Count).FirstOrDefault()?.Champion;
                        var secondRecentChampion = gameStats.Where(o => o.Champion != firstRecentChampion).Select(o => o.Champion).GroupBy(o => o).Select(o => new { Champion = o.Key, Count = o.Count() }).OrderByDescending(o => o.Count).FirstOrDefault()?.Champion;
                        var thirdRecentChampion = gameStats.Where(o => o.Champion != firstRecentChampion && o.Champion != secondRecentChampion).Select(o => o.Champion).GroupBy(o => o).Select(o => new { Champion = o.Key, Count = o.Count() }).OrderByDescending(o => o.Count).FirstOrDefault()?.Champion;
                        context.LolTournamentPlayers.Add(new LolTournamentPlayer() {
                            Tournament = tournament,
                            Player = player,
                            AverageAssists = numberOfGames != 0 ? assists / numberOfGames : default(double?),
                            AverageDeaths = numberOfGames != 0 ? deaths / numberOfGames : default(double?),
                            AverageKills = numberOfGames != 0 ? kills / numberOfGames : default(double?),
                            AverageGoldEarned = numberOfGames != 0 ? kills / numberOfGames : default(double?),
                            AverageMinionsKilled = numberOfGames != 0 ? minionsKilled / numberOfGames : default(double?),
                            FavouriteChampion1 = firstRecentChampion,
                            FavouriteChampion2 = secondRecentChampion,
                            FavouriteChampion3 = thirdRecentChampion,
                            ChampionsPlayed = championsPlayed,
                            GoldPerMinute = totalTimeInMInutes != 0 ? goldEarned / totalTimeInMInutes : default(double?),
                            MinionsPerMinute = totalTimeInMInutes != 0 ? minionsKilled / totalTimeInMInutes : default(double?),
                            KillParticipation = teamKills != 0 ? kills / teamKills : default(double?),
                            DamageShare = teamDamage != 0 ? damage / teamDamage : default(double?)

                        });
                    }
                }

            }
            context.SaveChanges();
        }

    }
}
