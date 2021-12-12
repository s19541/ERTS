using ErtsApplication.DTO;
using ErtsModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ErtsApplication.DAL {
    public class SerieDbService : ISerieDbService {
        public ErtsContext Context { get; set; }
        public SerieDbService(ErtsContext dbContext) {
            Context = dbContext;
        }
        public ActionResult<IEnumerable<SerieShortDto>> GetSeriesShort(int leagueId) {
            List<SerieShortDto> serieShortDtos = new List<SerieShortDto>();
            var series = Context.Series.Where(o => o.League.Id == leagueId).ToList();

            foreach (var serie in series) {
                var serieShortDto = new SerieShortDto() {
                    Id = serie.Id,
                    Name = serie.Name,
                    StartTime = serie.StartTime,
                    EndTime = serie.EndTime
                };
                serieShortDtos.Add(serieShortDto);
            }
            return serieShortDtos.OrderByDescending(x => x.StartTime).ToList();
        }
    }
}
