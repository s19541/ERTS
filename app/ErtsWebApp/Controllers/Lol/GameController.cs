using ErtsApplication.DAL;
using ErtsApplication.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ErtsWebApp.Controllers.Lol
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameDbService _dbService;
        public GameController(IGameDbService dbService)
        {
            _dbService = dbService;
        }
        [Route("[action]/{matchId}")]
        [HttpGet]
        public ActionResult<IEnumerable<LolGameStatsDto>> GetLolMatchGamesStatsLol(int matchId)
        {
            return _dbService.GetLolMatchGamesStats(matchId);
        }

    }
}
