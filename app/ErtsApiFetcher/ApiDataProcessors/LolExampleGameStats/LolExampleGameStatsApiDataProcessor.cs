using ErtsModel;
using ErtsModel.Entities;
using ErtsModel.Entities.Lol;
using ErtsModel.Enums;
using System;
using System.Linq;

namespace ErtsApiFetcher.ApiDataProcessors.LolExampleGameStats {

    public class LolExampleGameStatsApiDataProcessor : ApiDataProcessor<LolExampleGameStatsApiDataProcessorParameter> {
        public LolExampleGameStatsApiDataProcessor(ErtsContext context) : base(context) {

        }

        protected override void ProcessInternal(LolExampleGameStatsApiDataProcessorParameter parameter) {
            var random = new Random();
            var champions = context.LolChampions.ToList();
            context.SaveChanges();

            foreach (var newMatch in parameter.Matches) {
                var newGames = newMatch.Games.Where(apiGame => !context.LolGameTeams.Any(contextGame => contextGame.Game == apiGame) && apiGame.EndTime != default);

                foreach (var newGame in newGames) {
                    CreateGameTeamStats(newGame, newMatch.Team1, LolColor.blue);
                    CreateGameTeamStats(newGame, newMatch.Team2, LolColor.red);
                    CreateGameTeamPlayersStats(newGame, newMatch.Team1);
                    CreateGameTeamPlayersStats(newGame, newMatch.Team2);
                }
            }
        }

        private void CreateGameTeamStats(Game newGame, Team team, LolColor color) {
            var random = new Random();
            var champions = context.LolChampions.ToList();

            context.LolGameTeams.Add(new LolGameTeam() {
                Team = team,
                Game = newGame,
                Color = color,
                CloudDrakeKilled = 1,
                ElderDrakeKilled = 2,
                TurretDestroyed = 3,
                Ban1 = champions[random.Next(champions.Count)],
                Ban2 = champions[random.Next(champions.Count)],
                Ban3 = champions[random.Next(champions.Count)],
                Ban4 = champions[random.Next(champions.Count)],
                Ban5 = champions[random.Next(champions.Count)]
            });
        }

        private void CreateGameTeamPlayersStats(Game newGame, Team team) {
            var random = new Random();
            var champions = context.LolChampions.ToList();
            var spells = context.LolSpells.ToList();

            LolRole[] availableRoles = { LolRole.top, LolRole.jun, LolRole.mid, LolRole.adc, LolRole.sup };

            foreach (var player in team.Players) {
                var role = LolRole.sub;

                if (availableRoles.Length != 0) {
                    role = availableRoles[random.Next(availableRoles.Length)];
                    availableRoles = availableRoles.Where(e => e != role).ToArray();
                }

                var gamePlayer = new LolGamePlayer() {
                    Player = player,
                    Game = newGame,
                    Role = role,
                    Kills = 2,
                    Deaths = 3,
                    DamageDealtToChamps = 65,
                    Champion = champions[random.Next(champions.Count)],
                    Spell1 = spells[random.Next(spells.Count)],
                    Spell2 = spells[random.Next(spells.Count)]
                };
                context.LolGamePlayers.Add(gamePlayer);

                GenerateGamePlayerItems(gamePlayer);
            }
        }

        private void GenerateGamePlayerItems(LolGamePlayer gamePlayer) {
            var random = new Random();
            var items = context.LolItems.Where(item => !item.IsTrinket).ToList();
            var trinkets = context.LolItems.Where(item => item.IsTrinket).ToList();
            context.LolGamePlayerItems.Add(new LolGamePlayerItem() {
                GamePlayer = gamePlayer,
                Item = trinkets[random.Next(trinkets.Count)]
            });

            for (var i = 0; i < random.Next(7); i++) {
                context.LolGamePlayerItems.Add(new LolGamePlayerItem() {
                    GamePlayer = gamePlayer,
                    Item = items[random.Next(items.Count)]
                });
            }
        }
    }
}