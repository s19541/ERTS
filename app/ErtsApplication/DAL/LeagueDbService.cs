using ErtsApplication.DTO;
using ErtsModel;
using ErtsModel.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ErtsApplication.DAL {
    public class LeagueDbService : ILeagueDbService {
        public ErtsContext Context { get; set; }
        public LeagueDbService(ErtsContext dbContext) {
            Context = dbContext;
        }

        public ActionResult<LeagueDto> GetLeague(int leagueId) {
            var contextLeague = Context.Leagues.Where(p => p.Id == leagueId).FirstOrDefault();
            return new LeagueDto() {
                Name = contextLeague.Name,
                ImageUrl = contextLeague.ImageUrl,
                Url = contextLeague.Url
            };
        }

        public ActionResult<IEnumerable<LeagueImageDto>> GetLeagueImages(GameType gameType, string fragment) {
            List<LeagueImageDto> leagueImageDtos = new List<LeagueImageDto>();
            var leagues = Context.Leagues.Where(contextLeague => contextLeague.GameType == gameType && (fragment == null || contextLeague.Name.ToLower().Contains(fragment))).ToList();

            foreach (var league in leagues) {
                var leagueImageDto = new LeagueImageDto() {
                    Id = league.Id,
                    ImageUrl = league.ImageUrl,
                    Name = league.Name
                };
                leagueImageDtos.Add(leagueImageDto);
            }
            return leagueImageDtos;
        }
    }
}
