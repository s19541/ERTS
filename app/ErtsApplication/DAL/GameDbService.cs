using ErtsApplication.DTO;
using ErtsModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ErtsApplication.DAL {
    public class GameDbService : IGameDbService {
        public ErtsContext Context { get; set; }
        public GameDbService(ErtsContext dbContext) {
            Context = dbContext;
        }

        public ActionResult<LolGameFullStatsDto> GetLolGameStats(int gameId) {

            var game = Context.Games.Where(o => o.Id == gameId && o.Winner != null && o.Winner.GameType == ErtsModel.Enums.GameType.lol).FirstOrDefault();

            if (game == null) {
                return null;
            }


            var ts = game.EndTime != null ? (game.EndTime - game.StartTime) : System.TimeSpan.Zero;
            var minutes = ts.TotalMinutes != 0 ? ((int)ts.TotalMinutes).ToString() : "00";
            if (minutes.Length == 1)
                minutes = "0" + minutes;
            var seconds = ts.TotalSeconds % 60 != 0 ? (ts.TotalSeconds % 60).ToString() : "00";
            if (seconds.Length == 1)
                seconds = "0" + seconds;

            var gameLength = minutes + ":" + seconds;

            var blueTeamStats = Context.LolGameTeams.Where(o => o.Game == game && o.Color == ErtsModel.Enums.LolColor.blue).FirstOrDefault();
            var redTeamStats = Context.LolGameTeams.Where(o => o.Game == game && o.Color == ErtsModel.Enums.LolColor.red).FirstOrDefault();

            var blueTeamStatsDto = new LolGameTeamFullStatsDto() {
                TeamId = blueTeamStats.Team.Id,
                TeamName = blueTeamStats.Team.Name,
                TeamImageUrl = blueTeamStats.Team.ImageUrl,
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
                FirstBlood = blueTeamStats.FirstBlood,
                FirstDragon = blueTeamStats.FirstDragon,
                FirstInhibitor = blueTeamStats.FirstInhibitor,
                FirstTurret = blueTeamStats.FirstTurret
            };
            var redTeamStatsDto = new LolGameTeamFullStatsDto() {
                TeamId = redTeamStats.Team.Id,
                TeamName = redTeamStats.Team.Name,
                TeamImageUrl = redTeamStats.Team.ImageUrl,
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
                FirstBlood = redTeamStats.FirstBlood,
                FirstDragon = redTeamStats.FirstDragon,
                FirstInhibitor = redTeamStats.FirstInhibitor,
                FirstTurret = redTeamStats.FirstTurret
            };

            var playerStatsDtos = new List<LolGamePlayerFullStatsDto>();

            var playerStatsList = Context.LolGamePlayers.Where(o => o.Game == game).ToList();

            foreach (var playerStats in playerStatsList) {
                var playerStatsDto = new LolGamePlayerFullStatsDto() {
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
                    ItemImages = Context.LolGamePlayerItems.Where(o => o.GamePlayer == playerStats).Select(o => o.Item).OrderBy(o => o.IsTrinket).Select(o => o.ImageUrl).ToList(),
                    PhysicalDamageDealt = playerStats.PhysicalDamageDealt,
                    PhysicalDamageDealtToChamps = playerStats.PhysicalDamageDealt,
                    MagicDamageDealt = playerStats.MagicDamageDealt,
                    MagicDamageDealtToChamps = playerStats.MagicDamageDealtToChamps,
                    TrueDamageDealt = playerStats.TrueDamageDealt,
                    TrueDamageDealtToChamps = playerStats.TrueDamageDealtToChamps,
                    DamageDealt = playerStats.DamageDealt,
                    DamageDealtToChamps = playerStats.DamageDealtToChamps,
                    DamageTaken = playerStats.DamageTaken,
                    NeutralMinionsKilled = playerStats.NeutralMinionsKilled,
                    EnemyNeutralMinionsKilled = playerStats.EnemyNeutralMinionsKilled,
                    TotalTimeCrowdControllDealt = playerStats.TotalTimeCrowdControlDealt,
                    TotalHeal = playerStats.TotalHeal,
                    TurretsDestroyed = playerStats.TurretsDestroyed,
                    FirstBlood = playerStats.FirstBlood,
                    FirstBloodAssist = playerStats.FirstBloodAssist,
                    GoldSpent = playerStats.GoldSpent,
                    LargestCriticalStrike = playerStats.LargestCriticalStrike,
                    LargestKillingSpree = playerStats.LargestKillingSpree,
                    LargestMultiKill = playerStats.LargestMultiKill,
                    InhibitorsDestroyed = playerStats.InhibitorsDestroyed,
                    Level = playerStats.Level,
                    WardsPlaced = playerStats.WardsPlaced,
                    WardsDestroyed = playerStats.WardsDestroyed,

                };
                playerStatsDtos.Add(playerStatsDto);
            }
            var blueTeamId = Context.LolGameTeams.Where(o => o.Game == game).Where(o => o.Color == ErtsModel.Enums.LolColor.blue).Select(o => o.Team.Id).FirstOrDefault();

            var blueTeamplayersStats = playerStatsDtos.Where(o => o.TeamId == blueTeamId).ToList();
            var redTeamplayersStats = playerStatsDtos.Where(o => o.TeamId != blueTeamId).ToList();

            var lolGameStatsDto = new LolGameFullStatsDto() {
                StartTime = game.StartTime,
                GameLength = gameLength,
                WinnerTeamId = game.Winner.Id,
                BlueTeamStats = blueTeamStatsDto,
                RedTeamStats = redTeamStatsDto,
                BlueTeamPlayersStats = blueTeamplayersStats.OrderBy(o => o.Role).ToList(),
                RedTeamPlayersStats = redTeamplayersStats.OrderBy(o => o.Role).ToList()
            };



            return lolGameStatsDto;


        }
    }
}
