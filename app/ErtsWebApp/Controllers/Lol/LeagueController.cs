using ErtsApplication.DAL.Lol;
using ErtsApplication.DTO;
using ErtsModel.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ErtsApplication.Controllers.Lol
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeagueController : ControllerBase
    {
        private readonly ILeagueDbService _dbService;
        public LeagueController(ILeagueDbService dbService)
        {
            _dbService = dbService;
        }

        [Route("[action]")]
        [HttpGet]
        public ActionResult<IEnumerable<LeagueDto>> Get()
        {
            return _dbService.GetLeagues(GameType.Lol);
        }

        [Route("[action]")]
        [HttpGet]
        public ActionResult<IEnumerable<LeagueImageDto>> GetLeagueImages()
        {
            return _dbService.GetLeagueImages(GameType.Lol);
        }
    }
}
