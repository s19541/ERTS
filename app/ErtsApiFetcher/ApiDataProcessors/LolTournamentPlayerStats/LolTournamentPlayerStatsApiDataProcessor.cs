using ErtsModel;
using ErtsModel.Entities;
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
                foreach (var team in GetAllTeamsFromTournament(tournament)) {
                    foreach (var player in team.Players) {
                        var assists = 0;
                        var kills = 0;
                        var teamKills = 0;
                        var deaths = 0;
                        var minionsKilled = 0;
                        var goldEarned = 0;
                        var numberOfGames = 0;
                        var totalTimeInMinutes = 0.0;
                        var damage = 0;
                        var teamDamage = 0;

                        foreach (var game in GetAllGamesOfTemInTournament(tournament, team)) {


                            var gamePlayer = context.LolGamePlayers.Where(gamePlayerContext => gamePlayerContext.Game == game && gamePlayerContext.Player == player).FirstOrDefault();
                            if (gamePlayer != null) {
                                teamKills += context.LolGamePlayers.Where(o => o.Game == game).Where(o => team.Players.Contains(o.Player)).Select(o => o.Kills).Sum();
                                teamDamage += context.LolGamePlayers.Where(o => o.Game == game).Where(o => team.Players.Contains(o.Player)).Select(o => o.DamageDealtToChamps).Sum();
                                numberOfGames++;
                                totalTimeInMinutes += (game.EndTime - game.StartTime).TotalMinutes;

                                assists += gamePlayer.Assists;
                                kills += gamePlayer.Kills;
                                deaths += gamePlayer.Deaths;
                                damage += gamePlayer.DamageDealtToChamps;
                                minionsKilled += gamePlayer.MinionsKilled;
                                goldEarned += gamePlayer.GoldEarned;
                            }

                        }
                        if (numberOfGames != 0) {
                            var gameStats = context.LolGamePlayers.Where(contextGamePlayer => context.Matches.Where(contextMatch => contextMatch.Games.Contains(contextGamePlayer.Game)).FirstOrDefault().Tournament == tournament && contextGamePlayer.Player == player).ToArray();
                            int championsPlayed = gameStats.Select(o => o.Champion).Distinct().Count();
                            var firstRecentChampion = gameStats.Select(o => o.Champion).GroupBy(o => o).Select(o => new { Champion = o.Key, Count = o.Count() }).OrderByDescending(o => o.Count).FirstOrDefault()?.Champion;
                            var secondRecentChampion = gameStats.Where(o => o.Champion != firstRecentChampion).Select(o => o.Champion).GroupBy(o => o).Select(o => new { Champion = o.Key, Count = o.Count() }).OrderByDescending(o => o.Count).FirstOrDefault()?.Champion;
                            var thirdRecentChampion = gameStats.Where(o => o.Champion != firstRecentChampion && o.Champion != secondRecentChampion).Select(o => o.Champion).GroupBy(o => o).Select(o => new { Champion = o.Key, Count = o.Count() }).OrderByDescending(o => o.Count).FirstOrDefault()?.Champion;

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

        private List<Game> GetAllGamesOfTemInTournament(Tournament tournament, Team team) {
            return context.Matches
                .Where(contextMatch => contextMatch.Tournament == tournament && contextMatch.EndTime != null && (contextMatch.Team1 == team || contextMatch.Team2 == team))
                .SelectMany(match => match.Games)
                .ToList();
        }

        private List<Team> GetAllTeamsFromTournament(Tournament tournament) {
            return context.Matches
                 .Where(contextMatch => contextMatch.Tournament == tournament)
                 .Select(contextMatch => contextMatch.Team1).ToList()
                 .Union(context.Matches
                 .Where(contextMatch => contextMatch.Tournament == tournament)
                 .Select(contextMatch => contextMatch.Team2)).ToList();
        }
    }
}

