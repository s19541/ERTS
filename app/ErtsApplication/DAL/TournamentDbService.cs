using ErtsApplication.DTO;
using ErtsModel;
using Microsoft.AspNetCore.Mvc;
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
            var tournamentIds = Context.Tournaments.Where(o => o.Serie.Id == serieId).Select(o => o.Id).ToList();

            foreach (int tournamentId in tournamentIds) {
                var tournamentShortDto = new TournamentShortDto() {
                    Id = tournamentId,
                    Name = Context.Tournaments.Where(p => p.Id == tournamentId).Select(p => p.Name).FirstOrDefault(),
                    StartTime = Context.Tournaments.Where(p => p.Id == tournamentId).Select(p => p.StartTime).FirstOrDefault(),
                    EndTime = Context.Tournaments.Where(p => p.Id == tournamentId).Select(p => p.EndTime).FirstOrDefault()
                };
                tournamentShortDtos.Add(tournamentShortDto);
            }
            return tournamentShortDtos;
        }

        public ActionResult<IEnumerable<TournamentTeamShortDto>> GetTournamentTeamsShort(int tournamentId) {
            List<TournamentTeamShortDto> tournamentTeamShortDtos = new List<TournamentTeamShortDto>();
            var tournamentTeamIds = Context.LolTournamentTeams.Where(o => o.Tournament.Id == tournamentId).Select(o => o.Id).ToList();

            foreach (int tournamentTeamId in tournamentTeamIds) {
                var teamId = Context.LolTournamentTeams.Where(p => p.Id == tournamentTeamId).Select(p => p.Team.Id).FirstOrDefault();
                var tournamentTeamShortDto = new TournamentTeamShortDto() {
                    MatchesWon = Context.LolTournamentTeams.Where(p => p.Id == tournamentTeamId).Select(p => p.MatchesWon).FirstOrDefault(),
                    MatchesLost = Context.LolTournamentTeams.Where(p => p.Id == tournamentTeamId).Select(p => p.MatchesLost).FirstOrDefault(),
                    GamesWon = Context.LolTournamentTeams.Where(p => p.Id == tournamentTeamId).Select(p => p.GamesWon).FirstOrDefault(),
                    GamesLost = Context.LolTournamentTeams.Where(p => p.Id == tournamentTeamId).Select(p => p.GamesLost).FirstOrDefault(),
                    TeamName = Context.Teams.Where(p => p.Id == teamId).Select(p => p.Name).FirstOrDefault(),
                    TeamImageUrl = Context.Teams.Where(p => p.Id == teamId).Select(p => p.ImageUrl).FirstOrDefault()
                };
                tournamentTeamShortDtos.Add(tournamentTeamShortDto);
            }
            tournamentTeamShortDtos = tournamentTeamShortDtos.OrderByDescending(x => x.MatchesWon).ThenBy(x => x.GamesLost).ToList();
            return tournamentTeamShortDtos;
        }

        public ActionResult<IEnumerable<LolTournamentPlayerStatsDto>> GetLolTournamentPlayerStats(int tournamentId) {
            List<LolTournamentPlayerStatsDto> lolTournamentPlayerStatsDtos = new List<LolTournamentPlayerStatsDto>();
            var tournamentPlayers = Context.LolTournamentPlayers.Where(o => o.Tournament.Id == tournamentId).ToList();

            foreach (var tournamentPlayer in tournamentPlayers) {

                var lolTournamentPlayerStatsDto = new LolTournamentPlayerStatsDto() {
                    PlayerNick = tournamentPlayer.Player.Nick,
                    TeamImageUrl = Context.Teams.Where(contextTeam => contextTeam.Players.Contains(tournamentPlayer.Player)).FirstOrDefault().ImageUrl,
                    Kills = tournamentPlayer.AverageKills,
                    Deaths = tournamentPlayer.AverageDeaths,
                    Assists = tournamentPlayer.AverageAssists,
                    Kda = tournamentPlayer.AverageDeaths == null ? null : tournamentPlayer.AverageDeaths != 0 ? ((tournamentPlayer.AverageKills + tournamentPlayer.AverageAssists) / tournamentPlayer.AverageDeaths).ToString() : (tournamentPlayer.AverageKills + tournamentPlayer.AverageAssists) == 0 ? "0" : "Perfect",
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
