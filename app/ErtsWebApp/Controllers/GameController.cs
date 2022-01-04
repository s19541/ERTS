using ErtsApplication.DAL;
using ErtsApplication.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ErtsWebApp.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase {
        private readonly IGameDbService _dbService;
        public GameController(IGameDbService dbService) {
            _dbService = dbService;
        }
        [Route("[action]/{gameId}")]
        [HttpGet]
        public ActionResult<LolGameFullStatsDto> GetLolGameStats(int gameId) {
            return _dbService.GetLolGameStats(gameId);
        }

    }
}
