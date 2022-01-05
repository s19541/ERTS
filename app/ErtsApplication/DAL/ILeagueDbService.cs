using ErtsApplication.DTO;
using ErtsModel.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ErtsApplication.DAL {
    public interface ILeagueDbService {
        ActionResult<LeagueDto> GetLeague(int leagueId);

        ActionResult<IEnumerable<LeagueImageDto>> GetLeagueImages(GameType gameType, string fragment);
    }
}
