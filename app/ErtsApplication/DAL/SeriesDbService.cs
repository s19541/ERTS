using ErtsApplication.DTO;
using ErtsModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ErtsApplication.DAL
{
    public class SeriesDbService : ISeriesDbService
    {
        public ErtsContext Context { get; set; }
        public SeriesDbService(ErtsContext dbContext)
        {
            Context = dbContext;
        }
        public ActionResult<IEnumerable<SeriesShortDto>> GetSeriesShort(int tournamentId)
        {
            List<SeriesShortDto> tournamentSeriesShortDtos = new List<SeriesShortDto>();
            var seriesIds = Context.Series.Where(o => o.Tournament.Id == tournamentId).Select(o => o.Id).ToList();
            foreach (int seriesId in seriesIds)
            {
                var blueTeam = Context.Series.Where(p => p.Id == seriesId).Select(p => p.BlueTeam).FirstOrDefault();
                var redTeam = Context.Series.Where(p => p.Id == seriesId).Select(p => p.RedTeam).FirstOrDefault();
                var games = Context.Series.Where(p => p.Id == seriesId).Select(p => p.Games).FirstOrDefault();
                var blueTeamGamesWon = 0;
                var redTeamGamesWon = 0;
                foreach (var game in games)
                {
                    if (game.Winner == blueTeam)
                        blueTeamGamesWon++;
                    else
                        redTeamGamesWon++;
                }
                var tournamentSeriesShortDto = new SeriesShortDto()
                {
                    Id = seriesId,
                    StartTime = Context.Series.Where(p => p.Id == seriesId).Select(p => p.StartTime).FirstOrDefault(),
                    EndTime = Context.Series.Where(p => p.Id == seriesId).Select(p => p.EndTime).FirstOrDefault(),
                    BlueTeamImageUrl = blueTeam.ImageUrl,
                    RedTeamImageUrl = redTeam.ImageUrl,
                    BlueTeamAcronym = blueTeam.Acronym,
                    RedTeamAcronym = redTeam.Acronym,
                    BlueTeamGamesWon = blueTeamGamesWon,
                    RedTeamGamesWon = redTeamGamesWon
                };
                tournamentSeriesShortDtos.Add(tournamentSeriesShortDto);
            }
            tournamentSeriesShortDtos.OrderByDescending(x => x.StartTime).ToList();

            return tournamentSeriesShortDtos;
        }
    }
}
