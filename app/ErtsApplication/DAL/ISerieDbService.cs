using ErtsApplication.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ErtsApplication.DAL {
    public interface ISerieDbService {
        ActionResult<IEnumerable<SerieShortDto>> GetSeriesShort(int leagueId);
    }
}
