using ErtsApplication.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ErtsApplication.DAL
{
    public interface ISeriesDbService
    {
        ActionResult<IEnumerable<SeriesShortDto>> GetSeriesShort(int tournamentId);
    }
}
