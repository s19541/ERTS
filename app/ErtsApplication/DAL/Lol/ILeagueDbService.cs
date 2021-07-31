using ErtsApplication.DTO;
using ErtsModel.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ErtsApplication.DAL.Lol
{
    public interface ILeagueDbService
    {
        ActionResult<IEnumerable<LeagueDto>> GetLeagues(GameType gameType);

        ActionResult<IEnumerable<LeagueImageDto>> GetLeagueImages(GameType gameType);
    }
}
