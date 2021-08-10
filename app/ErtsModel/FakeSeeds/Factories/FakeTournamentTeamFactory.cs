using ErtsModel.Entities;

namespace ErtsModel.FakeSeeds.Factories
{
    static class FakeTournamentTeamFactory
    {
        public static TournamentTeam Create(Team team, Tournament tournament)
        {

            var matchesPlayed = Faker.RandomNumber.Next(0, 18);
            var matchesWon = Faker.RandomNumber.Next(0, matchesPlayed);
            var matchesLost = matchesPlayed - matchesWon;
            var gamesPlayed = Faker.RandomNumber.Next(matchesPlayed, 54);
            var gamesWon = Faker.RandomNumber.Next(0, gamesPlayed);
            var gamesLost = gamesPlayed - gamesWon;




            return new TournamentTeam
            {
                Team = team,
                Tournament = tournament,
                MatchesWon = matchesWon,
                MatchesLost = matchesLost,
                GamesWon = gamesWon,
                GamesLost = gamesLost
            };
        }
    }
}