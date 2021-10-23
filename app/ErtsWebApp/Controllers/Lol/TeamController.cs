using ErtsApplication.DAL;
using ErtsApplication.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ErtsApplication.Controllers.Lol {
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase {
        private readonly ITeamDbService _dbService;
        public TeamController(ITeamDbService dbService) {
            _dbService = dbService;
        }

        [Route("[action]/{teamId}")]
        [HttpGet]
        public ActionResult<TeamDto> GetTeam(int teamId) {
            return _dbService.GetTeam(teamId);
        }
    }
}