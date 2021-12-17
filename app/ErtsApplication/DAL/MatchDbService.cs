using ErtsApplication.DTO;
using ErtsModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ErtsApplication.DAL {
    public class MatchDbService : IMatchDbService {
        public ErtsContext Context { get; set; }
        public MatchDbService(ErtsContext dbContext) {
            Context = dbContext;
        }
        public ActionResult<IEnumerable<MatchShortDto>> GetMatches(int tournamentId) {
            List<MatchShortDto> tournamentMatchesDtos = new List<MatchShortDto>();
            var matches = Context.Matches.Where(o => o.Tournament.Id == tournamentId).ToList();
            foreach (var match in matches) {

                var team1GamesWon = match.Games.Where(game => game.Winner == match.Team1).Count();
                var team2GamesWon = match.Games.Where(game => game.Winner == match.Team2).Count();
                var tournamentMatchDto = new MatchShortDto() {
                    Id = match.Id,
                    StartTime = match.StartTime,
                    EndTime = match.EndTime,
                    Team1ImageUrl = match.Team1.ImageUrl,
                    Team2ImageUrl = match.Team2.ImageUrl,
                    Team1Acronym = match.Team1.Acronym,
                    Team2Acronym = match.Team2.Acronym,
                    Team1GamesWon = team1GamesWon,
                    Team2GamesWon = team2GamesWon,
                    NumberOfGames = match.NumberOfGames
                };
                tournamentMatchesDtos.Add(tournamentMatchDto);
            }

            return tournamentMatchesDtos.OrderByDescending(x => x.StartTime).ToList();
        }

        public ActionResult<MatchDto> GetMatch(int matchId) {
            var match = Context.Matches.Where(contextMatch => contextMatch.Id == matchId).FirstOrDefault();
            if (match == null || match.Tournament.Serie.League.GameType != ErtsModel.Enums.GameType.lol)
                return null;
            var team1 = match.Team1;
            var team2 = match.Team2;
            var games = match.Games;
            var team1GamesWon = 0;
            var team2GamesWon = 0;
            var gameStatsDtos = new List<LolGameShortStatsDto>();
            foreach (var game in games) {
                if (game.Winner == team1)
                    team1GamesWon++;
                else
                    team2GamesWon++;

                var playersStatsDtos = new List<LolGamePlayerShortStatsDto>();

                var playersStats = Context.LolGamePlayers.Where(o => o.Game == game).ToList();

                foreach (var playerStats in playersStats) {
                    var playersStatsDto = new LolGamePlayerShortStatsDto() {
                        TeamId = Context.Teams.Where(o => o.Players.Contains(playerStats.Player)).Select(o => o.Id).FirstOrDefault(),
                        PlayerNick = playerStats.Player.Nick,
                        Role = playerStats.Role,
                        ChampionImageUrl = playerStats.Champion.ImageUrl,
                        Kills = playerStats.Kills,
                        Deaths = playerStats.Deaths,
                        Assists = playerStats.Assists,
                        GoldEarned = playerStats.GoldEarned,
                        Cs = playerStats.MinionsKilled,
                        Spell1ImageUrl = playerStats.Spell1.ImageUrl,
                        Spell2ImageUrl = playerStats.Spell2.ImageUrl,
                        ItemImages = Context.LolGamePlayerItems.Where(o => o.GamePlayer == playerStats).Select(o => o.Item).OrderBy(o => o.IsTrinket).Select(o => o.ImageUrl).ToList()
                    };
                    playersStatsDtos.Add(playersStatsDto);
                }
                var ts = (game.EndTime - game.StartTime);
                var minutes = ts.TotalMinutes != 0 ? ((int)ts.TotalMinutes).ToString() : "00";
                if (minutes.Length == 1)
                    minutes = "0" + minutes;
                var seconds = ts.TotalSeconds % 60 != 0 ? (ts.TotalSeconds % 60).ToString() : "00";
                if (seconds.Length == 1)
                    seconds = "0" + seconds;

                var gameLength = minutes + ":" + seconds;
                var blueTeamId = Context.LolGameTeams.Where(o => o.Game == game).Where(o => o.Color == ErtsModel.Enums.LolColor.blue).Select(o => o.Team.Id).FirstOrDefault();
                var blueTeamplayersStats = playersStatsDtos.Where(o => o.TeamId == blueTeamId).ToList();
                var redTeamplayersStats = playersStatsDtos.Where(o => o.TeamId != blueTeamId).ToList();

                var blueTeamStats = Context.LolGameTeams.Where(o => o.Game == game && o.Color == ErtsModel.Enums.LolColor.blue).FirstOrDefault();
                var redTeamStats = Context.LolGameTeams.Where(o => o.Game == game && o.Color == ErtsModel.Enums.LolColor.red).FirstOrDefault();

                var blueTeamStatsDto = new LolGameTeamShortStatsDto() {
                    TeamId = blueTeamStats.Team.Id,
                    BaronKilled = blueTeamStats.BaronKilled,
                    MountainDrakeKilled = blueTeamStats.MountainDrakeKilled,
                    InfernalDrakeKilled = blueTeamStats.InfernalDrakeKilled,
                    OceanDrakeKilled = blueTeamStats.OceanDrakeKilled,
                    CloudDrakeKilled = blueTeamStats.CloudDrakeKilled,
                    ElderDrakeKilled = blueTeamStats.ElderDrakeKilled,
                    HeraldKilled = blueTeamStats.HeraldKilled,
                    GoldEarned = blueTeamStats.GoldEarned,
                    Kills = blueTeamStats.Kills,
                    TurretDestroyed = blueTeamStats.TurretDestroyed,
                    InhibitorDestroyed = blueTeamStats.InhibitorDestroyed,
                    Ban1ImageUrl = blueTeamStats.Ban1.ImageUrl,
                    Ban2ImageUrl = blueTeamStats.Ban2.ImageUrl,
                    Ban3ImageUrl = blueTeamStats.Ban3.ImageUrl,
                    Ban4ImageUrl = blueTeamStats.Ban4.ImageUrl,
                    Ban5ImageUrl = blueTeamStats.Ban5.ImageUrl
                };

                var redTeamStatsDto = new LolGameTeamShortStatsDto() {
                    TeamId = redTeamStats.Team.Id,
                    BaronKilled = redTeamStats.BaronKilled,
                    MountainDrakeKilled = redTeamStats.MountainDrakeKilled,
                    InfernalDrakeKilled = redTeamStats.InfernalDrakeKilled,
                    OceanDrakeKilled = redTeamStats.OceanDrakeKilled,
                    CloudDrakeKilled = redTeamStats.CloudDrakeKilled,
                    ElderDrakeKilled = redTeamStats.ElderDrakeKilled,
                    HeraldKilled = redTeamStats.HeraldKilled,
                    GoldEarned = redTeamStats.GoldEarned,
                    Kills = redTeamStats.Kills,
                    TurretDestroyed = redTeamStats.TurretDestroyed,
                    InhibitorDestroyed = redTeamStats.InhibitorDestroyed,
                    Ban1ImageUrl = redTeamStats.Ban1.ImageUrl,
                    Ban2ImageUrl = redTeamStats.Ban2.ImageUrl,
                    Ban3ImageUrl = redTeamStats.Ban3.ImageUrl,
                    Ban4ImageUrl = redTeamStats.Ban4.ImageUrl,
                    Ban5ImageUrl = redTeamStats.Ban5.ImageUrl
                };

                var gameStatsDto = new LolGameShortStatsDto() {
                    Id = game.Id,
                    GameLength = gameLength,
                    StartTime = game.StartTime,
                    WinnerTeamId = game.Winner.Id,
                    BlueTeamid = blueTeamId,
                    RedTeamStats = redTeamStatsDto,
                    BlueTeamStats = blueTeamStatsDto,
                    BlueTeamPlayersStats = blueTeamplayersStats.OrderBy(o => o.Role).ToList(),
                    RedTeamPlayersStats = redTeamplayersStats.OrderBy(o => o.Role).ToList()
                };
                gameStatsDtos.Add(gameStatsDto);
            }


            return new MatchDto() {

                Team1Id = team1.Id,
                Team2Id = team2.Id,
                Team1Name = team1.Name,
                Team2Name = team2.Name,
                MatchShortDto = new MatchShortDto() {
                    Id = matchId,
                    StartTime = Context.Matches.Where(p => p.Id == matchId).Select(p => p.StartTime).FirstOrDefault(),
                    EndTime = Context.Matches.Where(p => p.Id == matchId).Select(p => p.EndTime).FirstOrDefault(),
                    Team1ImageUrl = team1.ImageUrl,
                    Team2ImageUrl = team2.ImageUrl,
                    Team1Acronym = team1.Acronym,
                    Team2Acronym = team2.Acronym,
                    Team1GamesWon = team1GamesWon,
                    Team2GamesWon = team2GamesWon
                },
                StreamUrl = Context.Matches.Where(p => p.Id == matchId).Select(p => p.StreamUrl).FirstOrDefault(),
                Games = gameStatsDtos
            };
        }
    }
}
