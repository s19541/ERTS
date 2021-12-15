using ErtsModel;
using ErtsModel.Entities.Lol;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ErtsApiFetcher.ApiDataProcessors.LolTournamentPlayerStats {

    public class LolTournamentPlayerStatsApiDataProcessor : ApiDataProcessor<LolTournamentPlayerStatsApiDataProcessorParameter> {
        public LolTournamentPlayerStatsApiDataProcessor(ErtsContext context) : base(context) {

        }

        protected override void ProcessInternal(LolTournamentPlayerStatsApiDataProcessorParameter parameter) {
            context.LolTournamentPlayers.RemoveRange(context.LolTournamentPlayers.Where(contextTournament => parameter.Tournaments.Contains(contextTournament.Tournament)));
            context.SaveChanges();

            foreach (var tournament in parameter.Tournaments) {
                var teams = context.Matches.Where(contextMatch => contextMatch.Tournament == tournament).Select(contextMatch => contextMatch.Team1).ToArray().Union(context.Matches.Where(contextMatch => contextMatch.Tournament == tournament).Select(contextMatch => contextMatch.Team2).ToArray()).Distinct();
                foreach (var team in teams) {
                    foreach (var player in team.Players) {
                        var matches = context.Matches.Where(contextMatch => contextMatch.Tournament == tournament && contextMatch.EndTime != null && (contextMatch.Team1 == team || contextMatch.Team2 == team)).ToArray();

                        var gameStats = context.LolGamePlayers.Where(contextGamePlayer => context.Matches.Where(contextMatch => contextMatch.Games.Contains(contextGamePlayer.Game)).FirstOrDefault().Tournament == tournament && contextGamePlayer.Player == player).ToList();

                        var kills = gameStats.Sum(gameStats => gameStats.Kills);
                        var deaths = gameStats.Sum(gameStats => gameStats.Deaths);
                        var assists = gameStats.Sum(gameStats => gameStats.Assists);
                        var minionsKilled = gameStats.Sum(gameStats => gameStats.MinionsKilled);
                        var goldEarned = gameStats.Sum(gameStats => gameStats.GoldEarned);
                        var damage = gameStats.Sum(gameStats => gameStats.DamageDealtToChamps);

                        var teamGameStats = context.LolGamePlayers.Where(contextGamePlayer => context.Matches.Where(contextMatch => contextMatch.Games.Contains(contextGamePlayer.Game)).FirstOrDefault().Tournament == tournament && team.Players.Contains(contextGamePlayer.Player)).ToList();
                        var teamKills = teamGameStats.Sum(gameStats => gameStats.Kills);
                        var teamDamage = teamGameStats.Sum(gameStats => gameStats.DamageDealtToChamps);

                        var numberOfGames = gameStats.Count;
                        var totalTimeInMinutes = gameStats.Sum(gameStats => (gameStats.Game.EndTime - gameStats.Game.StartTime).TotalMinutes);


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
                            AverageGoldEarned = numberOfGames != 0 ? goldEarned / numberOfGames : default(double?),
                            AverageMinionsKilled = numberOfGames != 0 ? minionsKilled / numberOfGames : default(double?),
                            FavouriteChampion1 = firstRecentChampion,
                            FavouriteChampion2 = secondRecentChampion,
                            FavouriteChampion3 = thirdRecentChampion,
                            ChampionsPlayed = championsPlayed,
                            GoldPerMinute = totalTimeInMinutes != 0 ? goldEarned / totalTimeInMinutes : default(double?),
                            MinionsPerMinute = totalTimeInMinutes != 0 ? minionsKilled / totalTimeInMinutes : default(double?),
                            KillParticipation = teamKills != 0 ? kills / teamKills : default(double?),
                            DamageShare = teamDamage != 0 ? damage / teamDamage : default(double?)

                        });
                    }
                }

            }
        }
    }
}
