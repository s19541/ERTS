using ErtsApplication.DTO;
using ErtsModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ErtsApplication.DAL
{
    public class TournamentDbService : ITournamentDbService
    {
        public ErtsContext Context { get; set; }
        public TournamentDbService(ErtsContext dbContext)
        {
            Context = dbContext;
        }
        public ActionResult<IEnumerable<TournamentShortDto>> GetTournamentsShort(int leagueId)
        {
            List<TournamentShortDto> tournamentShortDtos = new List<TournamentShortDto>();
            var tournamentIds = Context.Tournaments.Where(o => o.League.Id == leagueId).Select(o => o.Id).ToList();

            foreach (int tournamentId in tournamentIds)
            {
                var tournamentShortDto = new TournamentShortDto()
                {
                    Id = tournamentId,
                    Name = Context.Tournaments.Where(p => p.Id == tournamentId).Select(p => p.Name).FirstOrDefault(),
                    StartTime = Context.Tournaments.Where(p => p.Id == tournamentId).Select(p => p.StartTime).FirstOrDefault(),
                    EndTime = Context.Tournaments.Where(p => p.Id == tournamentId).Select(p => p.EndTime).FirstOrDefault()
                };
                tournamentShortDtos.Add(tournamentShortDto);
            }
            return tournamentShortDtos;
        }

        public ActionResult<IEnumerable<TournamentTeamShortDto>> GetTournamentTeamsShort(int tournamentId)
        {
            List<TournamentTeamShortDto> tournamentTeamShortDtos = new List<TournamentTeamShortDto>();
            var tournamentTeamIds = Context.TournamentTeams.Where(o => o.Tournament.Id == tournamentId).Select(o => o.Id).ToList();

            foreach (int tournamentTeamId in tournamentTeamIds)
            {
                var teamId = Context.TournamentTeams.Where(p => p.Id == tournamentTeamId).Select(p => p.Team.Id).FirstOrDefault();
                var tournamentTeamShortDto = new TournamentTeamShortDto()
                {
                    MatchesWon = Context.TournamentTeams.Where(p => p.Id == tournamentTeamId).Select(p => p.MatchesWon).FirstOrDefault(),
                    MatchesLost = Context.TournamentTeams.Where(p => p.Id == tournamentTeamId).Select(p => p.MatchesLost).FirstOrDefault(),
                    GamesWon = Context.TournamentTeams.Where(p => p.Id == tournamentTeamId).Select(p => p.GamesWon).FirstOrDefault(),
                    GamesLost = Context.TournamentTeams.Where(p => p.Id == tournamentTeamId).Select(p => p.GamesLost).FirstOrDefault(),
                    TeamName = Context.Teams.Where(p => p.Id == teamId).Select(p => p.Name).FirstOrDefault(),
                    TeamImageUrl = Context.Teams.Where(p => p.Id == teamId).Select(p => p.ImageUrl).FirstOrDefault()
                };
                tournamentTeamShortDtos.Add(tournamentTeamShortDto);
            }
            tournamentTeamShortDtos = tournamentTeamShortDtos.OrderByDescending(x => x.MatchesWon).ThenBy(x => x.GamesLost).ToList();
            return tournamentTeamShortDtos;
        }

        public ActionResult<IEnumerable<LolTournamentPlayerStatsDto>> GetLolTournamentPlayerStats(int tournamentId)
        {
            List<LolTournamentPlayerStatsDto> lolTournamentPlayerStatsDtos = new List<LolTournamentPlayerStatsDto>();
            var tournamentTeamIds = Context.TournamentTeams.Where(o => o.Tournament.Id == tournamentId).Select(o => o.Id).ToList();

            //var res = Context.TournamentTeams.Where(o => o.Tournament.Id == tournamentId).Select(t=>t.Team.Players
            

            foreach (int tournamentTeamId in tournamentTeamIds)
            {
                var players = Context.TournamentTeams.Where(o => o.Id == tournamentTeamId).Select(o => o.Team).Select(o => o.Players).FirstOrDefault();

                foreach (var player in players)
                {
                    var team = Context.TournamentTeams.Where(p => p.Id == tournamentTeamId).Select(p => p.Team).FirstOrDefault();
                    var gamesStats = Context.LolGamePlayers.Where(o => o.Player == player).ToList();

                    int kills = 0;
                    int deaths = 0;
                    int assists = 0;
                    int cs = 0;
                    int gold = 0;
                    double gameTimeInMinutes = 0;
                    double damageShare = 0;
                    double killParticipation = 0;
                    foreach (var gameStats in gamesStats)
                    {
                        kills += gameStats.Kills;
                        deaths += gameStats.Deaths;
                        assists += gameStats.Assists;
                        cs += gameStats.MinionsKilled;
                        gold += gameStats.GoldEarned;
                        gameTimeInMinutes += (gameStats.Game.EndTime - gameStats.Game.StartTime).TotalMinutes;
                        var totalTeamDamageDealt = Context.LolGamePlayers.Where(o => o.Game == gameStats.Game).Where(o => team.Players.Contains(o.Player)).Select(o => o.DamageDealtToChamps).Sum();
                        damageShare += (double)gameStats.DamageDealtToChamps / (totalTeamDamageDealt != 0 ? totalTeamDamageDealt : 1);
                        var totalTeamKills = Context.LolGameTeam.Where(o => o.Game == gameStats.Game).Where(o => o.Team == team).Select(o => o.Kills).Sum();
                        killParticipation += (double)(gameStats.Kills + gameStats.Assists) / (totalTeamKills != 0 ? totalTeamKills : 1);

                    }
                    double averageKills = kills / gamesStats.Count();
                    double averageDeaths = deaths / gamesStats.Count();
                    double averageAssists = assists / gamesStats.Count();
                    double averageCs = cs / gamesStats.Count();
                    double csPerMinute = cs / gameTimeInMinutes;
                    double averageGold = gold / gamesStats.Count();
                    double goldPerMinute = gold / gameTimeInMinutes;
                    double averageDamageShare = damageShare / gamesStats.Count();
                    double averageKillParticipation = killParticipation / gamesStats.Count();
                    int championsPlayed = gamesStats.Select(o => o.Champion).Distinct().Count();
                    var firstRecentChampion = gamesStats.Select(o => o.Champion).GroupBy(o => o).Select(o => new { Champion = o.Key, Count = o.Count() }).OrderByDescending(o => o.Count).FirstOrDefault().Champion;
                    var secondRecentChampion = gamesStats.Where(o => o.Champion != firstRecentChampion).Select(o => o.Champion).GroupBy(o => o).Select(o => new { Champion = o.Key, Count = o.Count() }).OrderByDescending(o => o.Count).FirstOrDefault().Champion;
                    var thirdRecentChampion = gamesStats.Where(o => o.Champion != firstRecentChampion && o.Champion != secondRecentChampion).Select(o => o.Champion).GroupBy(o => o).Select(o => new { Champion = o.Key, Count = o.Count() }).OrderByDescending(o => o.Count).FirstOrDefault().Champion;





                    var lolTournamentTeamPlayerStatsDto = new LolTournamentPlayerStatsDto()
                    {
                        PlayerNick = player.Nick,
                        TeamImageUrl = team.ImageUrl,
                        Kills = Math.Round(averageKills, 2),
                        Deaths = Math.Round(averageDeaths, 2),
                        Assists = Math.Round(averageAssists, 2),
                        Cs = Math.Round(averageCs, 2),
                        CsPerMinute = Math.Round(csPerMinute, 2),
                        Gold = Math.Round(averageGold, 2),
                        GoldPerMinute = Math.Round(goldPerMinute, 2),
                        DamageShare = Math.Round(averageDamageShare, 2),
                        KillParticipation = Math.Round(averageKillParticipation, 2),
                        ChampionsPlayed = championsPlayed,
                        FirstRecentChampionImageUrl = firstRecentChampion.ImageUrl,
                        SecondRecentChampionImageUrl = secondRecentChampion.ImageUrl,
                        ThirdRecentChampionImageUrl = thirdRecentChampion.ImageUrl
                    };
                    lolTournamentPlayerStatsDtos.Add(lolTournamentTeamPlayerStatsDto);
                }

            }

            lolTournamentPlayerStatsDtos = lolTournamentPlayerStatsDtos.OrderBy(x => x.TeamImageUrl).ToList();
            return lolTournamentPlayerStatsDtos;
        }
    }
}
