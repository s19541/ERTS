using ErtsApplication.DAL;
using ErtsApplication.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ErtsWebApp.Controllers.Lol
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private readonly ISeriesDbService _dbService;
        public SeriesController(ISeriesDbService dbService)
        {
            _dbService = dbService;
        }
        [Route("[action]/{tournamentId}")]
        [HttpGet]
        public ActionResult<IEnumerable<SeriesShortDto>> GetSeriesShort(int tournamentId)
        {
            return _dbService.GetSeriesShort(tournamentId);
        }
    }
}
