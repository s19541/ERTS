using ErtsModel;
using System.Linq;

namespace ErtsApiFetcher.ApiDataProcessors.Teams {
    public class TeamApiDataProcessor : ApiDataProcessor<TeamApiDataProcessorParameter> {
        public TeamApiDataProcessor(ErtsContext context) : base(context) { }

        protected override void ProcessInternal(TeamApiDataProcessorParameter parameter) {
            var apiTeams = parameter.DataFetcher.FetchTeams(parameter.FromTime);
            var newTeams = apiTeams.Where(apiTeam => !context.Teams.Any(contextTeam => contextTeam.ApiId == apiTeam.ApiId && contextTeam.GameType == apiTeam.GameType));
            context.Teams.AddRange(newTeams);

            var updatedTeams = apiTeams.Where(apiTeam => context.Teams.Any(contextTeam => contextTeam.ApiId == apiTeam.ApiId && contextTeam.GameType == apiTeam.GameType));
            foreach (var updatedTeam in updatedTeams) {
                var contextTeam = context.Teams.Where(contextTeam => contextTeam.ApiId == updatedTeam.ApiId).FirstOrDefault();
                contextTeam.Update(updatedTeam.Acronym, updatedTeam.GameType, updatedTeam.ImageUrl, updatedTeam.Name, updatedTeam.Players);
            }
        }
    }
}
