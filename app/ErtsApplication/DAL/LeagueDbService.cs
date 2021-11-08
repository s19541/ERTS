using ErtsApplication.DTO;
using ErtsModel;
using ErtsModel.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ErtsApplication.DAL
{
    public class LeagueDbService : ILeagueDbService
    {
        public ErtsContext Context { get; set; }
        public LeagueDbService(ErtsContext dbContext)
        {
            Context = dbContext;
        }

        public ActionResult<LeagueDto> GetLeague(int leagueId)
        {
            var contextLeague = Context.Leagues.Where(p => p.Id == leagueId).FirstOrDefault();
           return new LeagueDto()
            {
                Name = contextLeague.Name,
                ImageUrl = contextLeague.ImageUrl,
                Url = contextLeague.Url
            };
        }

        public ActionResult<IEnumerable<LeagueImageDto>> GetLeagueImages(GameType gameType)
        {
            List<LeagueImageDto> leagueImageDtos = new List<LeagueImageDto>();
            var leagueIds = Context.Leagues.Where(o => o.GameType == gameType).Select(o => o.Id).ToList();

            foreach (int leagueId in leagueIds)
            {
                var leagueImageDto = new LeagueImageDto()
                {
                    Id = leagueId,
                    ImageUrl = Context.Leagues.Where(p => p.Id == leagueId).Select(p => p.ImageUrl).FirstOrDefault(),
                    LeagueName = Context.Leagues.Where(p => p.Id == leagueId).Select(p => p.Name).FirstOrDefault()
                };
                leagueImageDtos.Add(leagueImageDto);
            }
            return leagueImageDtos;
        }
    }
}
