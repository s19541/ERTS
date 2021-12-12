using ErtsModel;
using ErtsModel.Entities.Lol;
using System;
using System.Linq;

namespace ErtsApiFetcher.ApiDataProcessors.LolExampleGameStats {

    public class LolExampleGameStatsApiDataProcessor : ApiDataProcessor<LolExampleGameStatsApiDataProcessorParameter> {
        public LolExampleGameStatsApiDataProcessor(ErtsContext context) : base(context) {

        }

        protected override void ProcessInternal(LolExampleGameStatsApiDataProcessorParameter parameter) {
            var random = new Random();
            var champions = context.LolChampions.ToArray();
            var spells = context.LolSpells.ToArray();
            var items = context.LolItems.Where(item => !item.IsTrinket).ToArray();
            var trinkets = context.LolItems.Where(item => item.IsTrinket).ToArray();

            foreach (var newMatch in parameter.Matches) {
                var newGames = newMatch.Games.Where(apiGame => !context.Games.Any(contextGame => contextGame.ApiId == apiGame.ApiId));

                foreach (var newGame in newGames) {
                    if (newGame.EndTime != null) {
                        context.LolGameTeams.Add(new LolGameTeam() {
                            Team = newMatch.Team1,
                            Game = newGame,
                            Color = ErtsModel.Enums.LolColor.blue,
                            Ban1 = champions[random.Next(champions.Count())],
                            Ban2 = champions[random.Next(champions.Count())],
                            Ban3 = champions[random.Next(champions.Count())],
                            Ban4 = champions[random.Next(champions.Count())],
                            Ban5 = champions[random.Next(champions.Count())]
                        });

                        context.LolGameTeams.Add(new LolGameTeam() {
                            Team = newMatch.Team2,
                            Game = newGame,
                            Color = ErtsModel.Enums.LolColor.red,
                            Ban1 = champions[random.Next(champions.Count())],
                            Ban2 = champions[random.Next(champions.Count())],
                            Ban3 = champions[random.Next(champions.Count())],
                            Ban4 = champions[random.Next(champions.Count())],
                            Ban5 = champions[random.Next(champions.Count())]
                        });
                        ErtsModel.Enums.LolRole[] rolesT1 = { ErtsModel.Enums.LolRole.top, ErtsModel.Enums.LolRole.jun, ErtsModel.Enums.LolRole.mid, ErtsModel.Enums.LolRole.adc, ErtsModel.Enums.LolRole.sup };

                        ErtsModel.Enums.LolRole[] rolesT2 = { ErtsModel.Enums.LolRole.top, ErtsModel.Enums.LolRole.jun, ErtsModel.Enums.LolRole.mid, ErtsModel.Enums.LolRole.adc, ErtsModel.Enums.LolRole.sup };


                        foreach (var player in newMatch.Team1.Players.Union(newMatch.Team2.Players)) {
                            var role = ErtsModel.Enums.LolRole.sub;
                            if (newMatch.Team1.Players.Contains(player)) {
                                if (rolesT1.Length != 0) {
                                    role = rolesT1[random.Next(rolesT1.Count())];
                                    rolesT1 = rolesT1.Where(e => e != role).ToArray();
                                }
                            } else {
                                if (rolesT2.Length != 0) {
                                    role = rolesT2[random.Next(rolesT2.Count())];
                                    rolesT2 = rolesT2.Where(e => e != role).ToArray();
                                }
                            }

                            var lolGamePlayer = new LolGamePlayer() {
                                Player = player,
                                Game = newGame,
                                Role = role,
                                Champion = champions[random.Next(champions.Count())],
                                Spell1 = spells[random.Next(spells.Count())],
                                Spell2 = spells[random.Next(spells.Count())]
                            };
                            context.LolGamePlayers.Add(lolGamePlayer);

                            context.LolGamePlayerItems.Add(new LolGamePlayerItem() {
                                GamePlayer = lolGamePlayer,
                                Item = trinkets[random.Next(trinkets.Count())]
                            });
                            for (int i = 0; i < random.Next(7); i++) {
                                context.LolGamePlayerItems.Add(new LolGamePlayerItem() {
                                    GamePlayer = lolGamePlayer,
                                    Item = items[random.Next(items.Count())]
                                });
                            }
                        }
                    }

                }
            }
        }
    }
}
