using ErtsApplication.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ErtsApplication.DAL
{
    public interface ITournamentDbService
    {
        ActionResult<IEnumerable<TournamentShortDto>> GetTournamentsShort(int leagueId);
        ActionResult<IEnumerable<TournamentTeamShortDto>> GetTournamentTeamsShort(int tournamentId);
    }
}
