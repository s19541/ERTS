using ErtsModel;
using System.Linq;

namespace ErtsApiFetcher.ApiDataProcessors.LolSpells {
    public class LolSpellApiDataProcessor : ApiDataProcessor<LolSpellApiDataProcessorParameter> {
        public LolSpellApiDataProcessor(ErtsContext context) : base(context) { }

        protected override void ProcessInternal(LolSpellApiDataProcessorParameter parameter) {
            var apiSpells = parameter.DataFetcher.FetchSpells();
            var newSpells = apiSpells.Where(apiSpell => !context.LolSpells.Any(contextSpell => contextSpell.Name == apiSpell.Name));
            context.AddRange(newSpells);
        }
    }
}
