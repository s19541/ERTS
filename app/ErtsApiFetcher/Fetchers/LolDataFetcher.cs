using ErtsApiFetcher.Services;
using ErtsModel;
using ErtsModel.Entities.Lol;
using PandaScore.NET.Entities.QueryOptions;
using System.Collections.Generic;

namespace ErtsApiFetcher.Fetchers {
    public class LolDataFetcher : DataFetcherBase {
        public LolDataFetcher(string token, ErtsContext context) : base(new DataService(token, "lol"), context) { }

        public IEnumerable<LolChampion> FetchChampions() {
            var query = new ChampionQueryOptions();
            query.Name.Sort();
            var results = provider.FetchAndCatch(lolService => lolService.GetChampions(query));

            var lolChampions = new List<LolChampion>();

            foreach (var result in results) {
                lolChampions.Add(new LolChampion() {
                    Name = result.Name,
                    ImageUrl = result.ImageUrl
                });
            }

            return lolChampions;
        }

        public IEnumerable<LolItem> FetchItems() {
            var query = new ItemQueryOptions();
            var results = provider.FetchAndCatch(lolService => lolService.GetItems(query));

            var lolItems = new List<LolItem>();

            foreach (var result in results) {
                lolItems.Add(new LolItem() {
                    Name = result.Name,
                    ImageUrl = result.ImageUrl,
                    IsTrinket = result.IsTrinket == null ? false : result.IsTrinket.Value
                });
            }

            return lolItems;
        }

        public IEnumerable<LolSpell> FetchSpells() {
            var query = new SpellQueryOptions();
            var results = provider.FetchAndCatch(lolService => lolService.GetSpells(query));

            var lolSpells = new List<LolSpell>();

            foreach (var result in results) {
                lolSpells.Add(new LolSpell() {
                    Name = result.Name,
                    ImageUrl = result.ImageUrl
                });
            }

            return lolSpells;
        }

    }
}
