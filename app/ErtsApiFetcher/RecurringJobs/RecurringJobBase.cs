using ErtsApiFetcher.Configurations;
using ErtsApiFetcher.Fetchers;
using ErtsModel;
using ErtsModel.Entities;
using ErtsModel.Entities.Lol;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ErtsApiFetcher.RecurringJobs {
    public abstract class RecurringJobBase {
        protected ErtsContext context;
        protected AppConfig appConfig;

        private string Token => appConfig.PandaScoreApiToken;

        protected CsgoDataFetcher csgoDataFetcher;

        protected LolDataFetcher lolDataFetcher;

        protected ValorantDataFetcher valorantDataFetcher;

        protected OwDataFetcher owDataFetcher;

        protected Dota2DataFetcher dota2DataFetcher;

        protected DateTime? from;

        public RecurringJobBase(ErtsContext context, AppConfig appConfig) {
            this.context = context;
            this.appConfig = appConfig;
        }

        protected void FetchAndSaveAllMatches() {
            FetchAndSaveLolMatches();
            FetchAndSaveCsgoMatches();
            FetchAndSaveValorantMatches();
            FetchAndSaveOwMatches();
            FetchAndSaveDota2Matches();
        }
        protected void FetchAndSaveCsgoMatches() {
            csgoDataFetcher = new CsgoDataFetcher(Token, context);

            var apiMatches = csgoDataFetcher.FetchMatches(from);
            var newMatches = apiMatches.Where(apiMatches => !context.Matches.Any(contextMatche => contextMatche.ApiId == apiMatches.ApiId)).ToArray();
            context.Matches.AddRange(newMatches);

            context.SaveChanges();

            CreateTournamentTeamStats(GetTournamentsFromMatches(newMatches));

            context.SaveChanges();
        }
        protected void FetchAndSaveValorantMatches() {
            valorantDataFetcher = new ValorantDataFetcher(Token, context);

            var apiMatches = valorantDataFetcher.FetchMatches(from);
            var newMatches = apiMatches.Where(apiMatches => !context.Matches.Any(contextMatche => contextMatche.ApiId == apiMatches.ApiId)).ToArray();
            context.Matches.AddRange(newMatches);

            context.SaveChanges();

            CreateTournamentTeamStats(GetTournamentsFromMatches(newMatches));

            context.SaveChanges();
        }
        protected void FetchAndSaveOwMatches() {
            owDataFetcher = new OwDataFetcher(Token, context);

            var apiMatches = owDataFetcher.FetchMatches(from);
            var newMatches = apiMatches.Where(apiMatches => !context.Matches.Any(contextMatche => contextMatche.ApiId == apiMatches.ApiId)).ToArray();
            context.Matches.AddRange(newMatches);

            context.SaveChanges();

            CreateTournamentTeamStats(GetTournamentsFromMatches(newMatches));

        }
        protected void FetchAndSaveDota2Matches() {
            dota2DataFetcher = new Dota2DataFetcher(Token, context);

            var apiMatches = dota2DataFetcher.FetchMatches(from);
            var newMatches = apiMatches.Where(apiMatches => !context.Matches.Any(contextMatche => contextMatche.ApiId == apiMatches.ApiId)).ToArray();
            context.Matches.AddRange(newMatches);

            context.SaveChanges();

            CreateTournamentTeamStats(GetTournamentsFromMatches(newMatches));

        }
        protected void FetchAndSaveLolMatches() {
            lolDataFetcher = new LolDataFetcher(Token, context);

            var apiMatches = lolDataFetcher.FetchMatches(from);
            var newMatches = apiMatches.Where(apiMatches => !context.Matches.Any(contextMatche => contextMatche.ApiId == apiMatches.ApiId)).ToArray();
            context.Matches.AddRange(newMatches);

            createLolGameStats(newMatches);

            context.SaveChanges();

            CreateLolTournamentTeamStats(GetTournamentsFromMatches(newMatches));
            CreateLolTournamentPlayerStats(GetTournamentsFromMatches(newMatches));

        }

        private void createLolGameStats(IEnumerable<Match> matches) {
            var random = new Random();
            var champions = context.LolChampions.ToArray();
            var spells = context.LolSpells.ToArray();
            var items = context.LolItems.Where(item => !item.IsTrinket).ToArray();
            var trinkets = context.LolItems.Where(item => item.IsTrinket).ToArray();

            foreach (var newMatch in matches) {
                var newGames = newMatch.Games.Where(apiGame => !context.Games.Any(contextGame => contextGame.ApiId == apiGame.ApiId));

                foreach (var newGame in newGames) {
                    if (newGame.EndTime != null) {
                        context.LolGameTeams.Add(new LolGameTeam() {
                            Team = newMatch.Team1,
                            Game = newGame,
                            Color = ErtsModel.Enums.LolColor.blue,
                            Ban1 = champions[random.Next(champions.Count())],
                            Ban2 = champions[random.Next(champions.Count())],
                            Ban3 = champions[random.Next(champions.Count())],
                            Ban4 = champions[random.Next(champions.Count())],
                            Ban5 = champions[random.Next(champions.Count())]
                        });

                        context.LolGameTeams.Add(new LolGameTeam() {
                            Team = newMatch.Team2,
                            Game = newGame,
                            Color = ErtsModel.Enums.LolColor.red,
                            Ban1 = champions[random.Next(champions.Count())],
                            Ban2 = champions[random.Next(champions.Count())],
                            Ban3 = champions[random.Next(champions.Count())],
                            Ban4 = champions[random.Next(champions.Count())],
                            Ban5 = champions[random.Next(champions.Count())]
                        });
                        ErtsModel.Enums.LolRole[] rolesT1 = { ErtsModel.Enums.LolRole.top, ErtsModel.Enums.LolRole.jun, ErtsModel.Enums.LolRole.mid, ErtsModel.Enums.LolRole.adc, ErtsModel.Enums.LolRole.sup };

                        ErtsModel.Enums.LolRole[] rolesT2 = { ErtsModel.Enums.LolRole.top, ErtsModel.Enums.LolRole.jun, ErtsModel.Enums.LolRole.mid, ErtsModel.Enums.LolRole.adc, ErtsModel.Enums.LolRole.sup };


                        foreach (var player in newMatch.Team1.Players.Union(newMatch.Team2.Players)) {
                            var role = ErtsModel.Enums.LolRole.sub;
                            if (newMatch.Team1.Players.Contains(player)) {
                                if (rolesT1.Length != 0) {
                                    role = rolesT1[random.Next(rolesT1.Count())];
                                    rolesT1 = rolesT1.Where(e => e != role).ToArray();
                                }
                            } else {
                                if (rolesT2.Length != 0) {
                                    role = rolesT2[random.Next(rolesT2.Count())];
                                    rolesT2 = rolesT2.Where(e => e != role).ToArray();
                                }
                            }

                            var lolGamePlayer = new LolGamePlayer() {
                                Player = player,
                                Game = newGame,
                                Role = role,
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

        }

        private IEnumerable<Tournament> GetTournamentsFromMatches(IEnumerable<Match> matches) {
            return matches.Select(match => match.Tournament).Distinct();
        }

        private void CreateTournamentTeamStats(IEnumerable<Tournament> tournaments) {
            context.TournamentTeams.RemoveRange(context.TournamentTeams.Where(o => tournaments.Contains(o.Tournament)));
            context.SaveChanges();

            foreach (var tournament in tournaments) {
                var teams = context.Matches.Where(contextMatch => contextMatch.Tournament == tournament).Select(contextMatch => contextMatch.Team1).ToArray().Union(context.Matches.Where(contextMatch => contextMatch.Tournament == tournament).Select(contextMatch => contextMatch.Team2).ToArray()).Distinct();

                foreach (var team in teams) {
                    var gamesLost = 0;
                    var gamesWon = 0;
                    var matchesWon = 0;
                    var matchesLost = 0;

                    var matches = context.Matches.Where(contextMatch => contextMatch.Tournament == tournament && contextMatch.EndTime != null && (contextMatch.Team1 == team || contextMatch.Team2 == team)).ToArray();
                    foreach (var match in matches) {
                        var matchGamesWon = 0;
                        var matchGamesLost = 0;
                        foreach (var game in match.Games) {
                            if (game.Winner == team)
                                matchGamesWon++;
                            else
                                matchGamesLost++;
                        }
                        gamesLost += matchGamesLost;
                        gamesWon += matchGamesWon;
                        if (matchGamesWon > matchGamesLost)
                            matchesWon++;
                        else if (matchGamesLost > matchGamesWon)
                            matchesLost++;
                    }

                    context.TournamentTeams.Add(new ErtsModel.Entities.TournamentTeam() {
                        Tournament = tournament,
                        Team = team,
                        GamesLost = gamesLost,
                        GamesWon = gamesWon,
                        MatchesWon = matchesWon,
                        MatchesLost = matchesLost,
                    });
                }
            }


            context.SaveChanges();
        }
        private void CreateLolTournamentTeamStats(IEnumerable<Tournament> tournaments) {
            context.LolTournamentTeams.RemoveRange(context.LolTournamentTeams.Where(contextTournament => tournaments.Contains(contextTournament.Tournament)));
            context.SaveChanges();
            foreach (var tournament in tournaments) {

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

                            foreach (var gameTeam in context.LolGameTeams.Where(contextGameTeam => contextGameTeam.Game == game && contextGameTeam.Team == team)) {
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

        private void CreateLolTournamentPlayerStats(IEnumerable<Tournament> tournaments) {
            context.LolTournamentPlayers.RemoveRange(context.LolTournamentPlayers.Where(contextTournament => tournaments.Contains(contextTournament.Tournament)));
            context.SaveChanges();

            foreach (var tournament in tournaments) {
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
