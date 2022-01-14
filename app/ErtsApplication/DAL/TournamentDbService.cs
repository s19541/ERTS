using ErtsApplication.DTO;
using ErtsModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ErtsApplication.DAL {
    public class TournamentDbService : ITournamentDbService {
        public ErtsContext Context { get; set; }
        public TournamentDbService(ErtsContext dbContext) {
            Context = dbContext;
        }
        public ActionResult<IEnumerable<TournamentShortDto>> GetTournamentsShort(int serieId) {
            List<TournamentShortDto> tournamentShortDtos = new List<TournamentShortDto>();
            var tournaments = Context.Tournaments.Where(o => o.Serie.Id == serieId).ToList();

            foreach (var tournament in tournaments) {
                var tournamentShortDto = new TournamentShortDto() {
                    Id = tournament.Id,
                    Name = tournament.Name,
                    StartTime = tournament.StartTime,
                    EndTime = tournament.EndTime
                };
                tournamentShortDtos.Add(tournamentShortDto);
            }
            return tournamentShortDtos.OrderByDescending(x => x.StartTime).ToList();
        }

        public ActionResult<IEnumerable<TournamentTeamShortDto>> GetTournamentTeamsShort(int tournamentId) {
            List<TournamentTeamShortDto> tournamentTeamShortDtos = new List<TournamentTeamShortDto>();
            var tournamentTeams = Context.TournamentTeams.Where(o => o.Tournament.Id == tournamentId).ToList();

            foreach (var tournamentTeam in tournamentTeams) {
                var team = tournamentTeam.Team;
                var tournamentTeamShortDto = new TournamentTeamShortDto() {
                    MatchesWon = tournamentTeam.MatchesWon,
                    MatchesLost = tournamentTeam.MatchesLost,
                    GamesWon = tournamentTeam.GamesWon,
                    GamesLost = tournamentTeam.GamesLost,
                    TeamName = team.Name,
                    TeamImageUrl = team.ImageUrl,
                    TeamId = team.Id
                };
                tournamentTeamShortDtos.Add(tournamentTeamShortDto);
            }
            return tournamentTeamShortDtos.OrderBy(x => x.MatchesLost).ThenByDescending(x => x.MatchesWon).ToList();
        }

        public ActionResult<IEnumerable<LolTournamentPlayerStatsDto>> GetLolTournamentPlayerStats(int tournamentId) {
            List<LolTournamentPlayerStatsDto> lolTournamentPlayerStatsDtos = new List<LolTournamentPlayerStatsDto>();
            var tournamentPlayers = Context.LolTournamentPlayers.Where(o => o.Tournament.Id == tournamentId).ToList();

            foreach (var tournamentPlayer in tournamentPlayers) {

                var lolTournamentPlayerStatsDto = new LolTournamentPlayerStatsDto() {
                    PlayerNick = tournamentPlayer.Player.Nick,
                    TeamImageUrl = Context.Teams.Where(contextTeam => contextTeam.Players.Contains(tournamentPlayer.Player)).FirstOrDefault().ImageUrl,
                    TeamId = Context.Teams.Where(contextTeam => contextTeam.Players.Contains(tournamentPlayer.Player)).FirstOrDefault().Id,
                    Kills = tournamentPlayer.AverageKills,
                    Deaths = tournamentPlayer.AverageDeaths,
                    Assists = tournamentPlayer.AverageAssists,
                    Kda = tournamentPlayer.AverageDeaths == null ? null : tournamentPlayer.AverageDeaths != 0 ? (Math.Round((float)((tournamentPlayer.AverageKills + tournamentPlayer.AverageAssists) / tournamentPlayer.AverageDeaths), 2)).ToString() : (tournamentPlayer.AverageKills + tournamentPlayer.AverageAssists) == 0 ? "0" : "Perfect",
                    Cs = tournamentPlayer.AverageMinionsKilled,
                    CsPerMinute = tournamentPlayer.MinionsPerMinute,
                    Gold = tournamentPlayer.AverageGoldEarned,
                    GoldPerMinute = tournamentPlayer.GoldPerMinute,
                    DamageShare = tournamentPlayer.DamageShare != null ? tournamentPlayer.DamageShare * 100 + "%" : null,
                    KillParticipation = tournamentPlayer.KillParticipation != null ? tournamentPlayer.KillParticipation * 100 + "%" : null,
                    ChampionsPlayed = tournamentPlayer.ChampionsPlayed,
                    FirstRecentChampionImageUrl = tournamentPlayer.FavouriteChampion1 != null ? tournamentPlayer.FavouriteChampion1.ImageUrl : "/images/lol/champion.png",
                    SecondRecentChampionImageUrl = tournamentPlayer.FavouriteChampion2 != null ? tournamentPlayer.FavouriteChampion2.ImageUrl : "/images/lol/champion.png",
                    ThirdRecentChampionImageUrl = tournamentPlayer.FavouriteChampion3 != null ? tournamentPlayer.FavouriteChampion3.ImageUrl : "/images/lol/champion.png"
                };
                lolTournamentPlayerStatsDtos.Add(lolTournamentPlayerStatsDto);

            }

            lolTournamentPlayerStatsDtos = lolTournamentPlayerStatsDtos.OrderBy(x => x.TeamImageUrl).ToList();
            return lolTournamentPlayerStatsDtos;
        }

        public ActionResult<IEnumerable<LolTournamentTeamStatsDto>> GetLolTournamentTeamStats(int tournamentId) {
            List<LolTournamentTeamStatsDto> lolTournamentTeamStatsDtos = new List<LolTournamentTeamStatsDto>();
            var tournamentTeams = Context.LolTournamentTeams.Where(o => o.Tournament.Id == tournamentId).ToList();
            foreach (var tournamentTeam in tournamentTeams) {
                var lolTournamentTeamStatsDto = new LolTournamentTeamStatsDto() {
                    TeamId = tournamentTeam.Team.Id,
                    TeamName = tournamentTeam.Team.Name,
                    TeamImageUrl = tournamentTeam.Team.ImageUrl,
                    Kills = tournamentTeam.AverageKills,
                    Assists = tournamentTeam.AverageAssists,
                    Deaths = tournamentTeam.AverageDeaths,
                    Gold = tournamentTeam.AverageGoldEarned,
                    Dragons = tournamentTeam.AverageDragonKilled,
                    Heralds = tournamentTeam.AverageHeraldKilled,
                    Barons = tournamentTeam.AverageBaronKilled,
                    Towers = tournamentTeam.AverageTowerDestroyed,
                    FirstRecentChampionImageUrl = tournamentTeam.FavouriteChampion1 != null ? tournamentTeam.FavouriteChampion1.ImageUrl : "/images/lol/champion.png",
                    SecondRecentChampionImageUrl = tournamentTeam.FavouriteChampion2 != null ? tournamentTeam.FavouriteChampion2.ImageUrl : "/images/lol/champion.png",
                    ThirdRecentChampionImageUrl = tournamentTeam.FavouriteChampion3 != null ? tournamentTeam.FavouriteChampion3.ImageUrl : "/images/lol/champion.png",
                    FourthRecentChampionImageUrl = tournamentTeam.FavouriteChampion4 != null ? tournamentTeam.FavouriteChampion4.ImageUrl : "/images/lol/champion.png",
                    FivethRecentChampionImageUrl = tournamentTeam.FavouriteChampion5 != null ? tournamentTeam.FavouriteChampion5.ImageUrl : "/images/lol/champion.png"

                };
                lolTournamentTeamStatsDtos.Add(lolTournamentTeamStatsDto);
            }

            return lolTournamentTeamStatsDtos;
        }
    }
}
