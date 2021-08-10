using ErtsApplication.DTO;
using ErtsModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ErtsApplication.DAL
{
    public class GameDbService : IGameDbService
    {
        public ErtsContext Context { get; set; }
        public GameDbService(ErtsContext dbContext)
        {
            Context = dbContext;
        }
        public ActionResult<IEnumerable<LolGameStatsDto>> GetLolMatchGamesStats(int matchId)
        {
            List<LolGameStatsDto> lolGameStatsDtos = new List<LolGameStatsDto>();

            var games = Context.Matches.Where(o => o.Id == matchId).Select(o => o.Games).FirstOrDefault();


            foreach (var game in games)
            {
                var blueTeamStats = Context.LolGameTeam.Where(o => o.Game == game && o.Color == ErtsModel.Enums.LolColor.blue).FirstOrDefault();
                var redTeamStats = Context.LolGameTeam.Where(o => o.Game == game && o.Color == ErtsModel.Enums.LolColor.red).FirstOrDefault();

                var gameLength = (game.EndTime - game.StartTime).TotalMinutes;

                var blueTeamStatsDto = new LolGameTeamStatsDto()
                {
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
                    Ban1ImageUrl = blueTeamStats.Ban1.ImageUrl,
                    Ban2ImageUrl = blueTeamStats.Ban2.ImageUrl,
                    Ban3ImageUrl = blueTeamStats.Ban3.ImageUrl,
                    Ban4ImageUrl = blueTeamStats.Ban4.ImageUrl,
                    Ban5ImageUrl = blueTeamStats.Ban5.ImageUrl,
                    FirstBaron = blueTeamStats.FirstBaron,
                    FirstDragon = blueTeamStats.FirstDragon,
                    FirstBlood = blueTeamStats.FirstBlood,
                    FirstInhibitor = blueTeamStats.FirstInhibitor,
                    FirstTurret = blueTeamStats.FirstTurret
                };

                var redTeamStatsDto = new LolGameTeamStatsDto()
                {
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
                    Ban1ImageUrl = redTeamStats.Ban1.ImageUrl,
                    Ban2ImageUrl = redTeamStats.Ban2.ImageUrl,
                    Ban3ImageUrl = redTeamStats.Ban3.ImageUrl,
                    Ban4ImageUrl = redTeamStats.Ban4.ImageUrl,
                    Ban5ImageUrl = redTeamStats.Ban5.ImageUrl,
                    FirstBaron = redTeamStats.FirstBaron,
                    FirstDragon = redTeamStats.FirstDragon,
                    FirstBlood = redTeamStats.FirstBlood,
                    FirstInhibitor = redTeamStats.FirstInhibitor,
                    FirstTurret = redTeamStats.FirstTurret
                };

                var playersStatsDtos = new List<LolGamePlayerShortStatsDto>();

                var playersStats = Context.LolGamePlayers.Where(o => o.Game == game).ToList();

                foreach (var playerStats in playersStats)
                {
                    var playersStatsDto = new LolGamePlayerShortStatsDto()
                    {
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
                        ItemImages = Context.LolGamePlayerItems.Where(o => o.GamePlayer == playerStats).Select(o => o.Item).Select(o => o.ImageUrl).ToList()
                    };
                    playersStatsDtos.Add(playersStatsDto);
                }

                var lolGameStatsDto = new LolGameStatsDto()
                {
                    StartTime = game.StartTime,
                    GameLength = gameLength,
                    WinnerTeamId = game.Winner.Id,
                    BlueTeamStats = blueTeamStatsDto,
                    RedTeamStats = redTeamStatsDto,
                    PlayersStats = playersStatsDtos
                };
                lolGameStatsDtos.Add(lolGameStatsDto);
            }


            return lolGameStatsDtos;
        }
    }
}
