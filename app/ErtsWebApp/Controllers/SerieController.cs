using ErtsApplication.DAL;
using ErtsApplication.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ErtsWebApp.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class SerieController : ControllerBase {
        private readonly ISerieDbService _dbService;
        public SerieController(ISerieDbService dbService) {
            _dbService = dbService;
        }
        [Route("[action]/{leagueId}")]
        [HttpGet]
        public ActionResult<IEnumerable<SerieShortDto>> GetSeriesShort(int leagueId) {
            return _dbService.GetSeriesShort(leagueId);
        }

    }
}
