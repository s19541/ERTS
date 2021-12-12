using ErtsModel;
using System.Linq;

namespace ErtsApiFetcher.ApiDataProcessors.Teams {
    public class TeamApiDataProcessor : ApiDataProcessor<TeamApiDataProcessorParameter> {
        public TeamApiDataProcessor(ErtsContext context) : base(context) { }

        protected override void ProcessInternal(TeamApiDataProcessorParameter parameter) {
            var apiTeams = parameter.DataFetcher.FetchTeams(parameter.FromTime);
            var newTeams = apiTeams.Where(apiTeam => !context.Teams.Any(contextTeam => contextTeam.ApiId == apiTeam.ApiId && contextTeam.GameType == apiTeam.GameType));
            context.Teams.AddRange(newTeams);

            var updateTeams = apiTeams.Where(apiTeam => context.Teams.Any(contextTeam => contextTeam.ApiId == apiTeam.ApiId && contextTeam.GameType == apiTeam.GameType));
            foreach (var updateTeam in updateTeams) {
                var contextTeam = context.Teams.Where(contextTeam => contextTeam.ApiId == updateTeam.ApiId).FirstOrDefault();
                contextTeam.Update(updateTeam.Acronym, updateTeam.GameType, updateTeam.ImageUrl, updateTeam.Name, updateTeam.Players);
            }
        }
    }
}
