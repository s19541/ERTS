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
                    //var matches = context.Matches.Where(contextMatch => contextMatch.Tournament == tournament && contextMatch.EndTime != null && (contextMatch.Team1 == team || contextMatch.Team2 == team)).ToList();


                    foreach (var player in team.Players) {

                        //var gameStats = context.LolGamePlayers.Where(contextGamePlayer => context.Matches.Where(contextMatch => contextMatch.Games.Contains(contextGamePlayer.Game)).FirstOrDefault().Tournament == tournament && team.Players.Contains(contextGamePlayer.Player)).ToList();
                        var gameStats = context.LolGamePlayers.Where(gameStats => context.Matches.Any(match => match.Tournament == tournament && match.Games.Contains(gameStats.Game)) && gameStats.Player == player).ToList();
                        var kills = gameStats.Sum(gameStats => gameStats.Kills);
                        var deaths = gameStats.Sum(gameStats => gameStats.Deaths);
                        var assists = gameStats.Sum(gameStats => gameStats.Assists);
                        var minionsKilled = gameStats.Sum(gameStats => gameStats.MinionsKilled);
                        var goldEarned = gameStats.Sum(gameStats => gameStats.GoldEarned);
                        var damage = gameStats.Sum(gameStats => gameStats.DamageDealtToChamps);

                        var numberOfGames = gameStats.Count;
                        var totalTimeInMinutes = gameStats.Sum(gameStats => (gameStats.Game.EndTime - gameStats.Game.StartTime).TotalMinutes);


                        int championsPlayed = gameStats.Select(o => o.Champion).Distinct().Count();
                        var firstRecentChampion = gameStats.Select(o => o.Champion).GroupBy(o => o).Select(o => new { Champion = o.Key, Count = o.Count() }).OrderByDescending(o => o.Count).FirstOrDefault()?.Champion;
                        var secondRecentChampion = gameStats.Where(o => o.Champion != firstRecentChampion).Select(o => o.Champion).GroupBy(o => o).Select(o => new { Champion = o.Key, Count = o.Count() }).OrderByDescending(o => o.Count).FirstOrDefault()?.Champion;
                        var thirdRecentChampion = gameStats.Where(o => o.Champion != firstRecentChampion && o.Champion != secondRecentChampion).Select(o => o.Champion).GroupBy(o => o).Select(o => new { Champion = o.Key, Count = o.Count() }).OrderByDescending(o => o.Count).FirstOrDefault()?.Champion;

                        var teamGameStats = context.LolGamePlayers.Where(gameStats => context.Matches.Any(match => match.Tournament == tournament && match.Games.Contains(gameStats.Game)) && context.LolGamePlayers.Any(gameStats2 => gameStats2.Player == player && gameStats2.Game == gameStats.Game)).ToList();
                        var teamKills = teamGameStats.Sum(gameStats => gameStats.Kills);
                        var teamDamage = teamGameStats.Sum(gameStats => gameStats.DamageDealtToChamps);

                        context.LolTournamentPlayers.Add(new LolTournamentPlayer() {
                            Tournament = tournament,
                            Player = player,
                            AverageAssists = numberOfGames != 0 ? Math.Round((float)assists / numberOfGames, 2) : 0,
                            AverageDeaths = numberOfGames != 0 ? Math.Round((float)deaths / numberOfGames, 2) : 0,
                            AverageKills = numberOfGames != 0 ? Math.Round((float)kills / numberOfGames, 2) : 0,
                            AverageGoldEarned = numberOfGames != 0 ? Math.Round((float)goldEarned / numberOfGames, 2) : 0,
                            AverageMinionsKilled = numberOfGames != 0 ? Math.Round((float)minionsKilled / numberOfGames, 2) : 0,
                            FavouriteChampion1 = firstRecentChampion,
                            FavouriteChampion2 = secondRecentChampion,
                            FavouriteChampion3 = thirdRecentChampion,
                            ChampionsPlayed = championsPlayed,
                            GoldPerMinute = totalTimeInMinutes != 0 ? Math.Round((float)goldEarned / totalTimeInMinutes, 2) : 0,
                            MinionsPerMinute = totalTimeInMinutes != 0 ? Math.Round((float)minionsKilled / totalTimeInMinutes, 2) : 0,
                            KillParticipation = teamKills != 0 ? Math.Round(kills / (float)teamKills, 2) : 0,
                            DamageShare = teamDamage != 0 ? Math.Round(damage / (float)teamDamage, 2) : 0
                        });
                    }
                }

            }
        }
    }
}
