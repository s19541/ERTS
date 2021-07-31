using ErtsApplication.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ErtsApplication.DAL.Lol
{
    public interface ITournamentDbService
    {
        ActionResult<IEnumerable<TournamentShortDto>> GetTournamentsShort(int leagueId);
    }
}
