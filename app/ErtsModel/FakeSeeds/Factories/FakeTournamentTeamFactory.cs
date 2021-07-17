using ErtsModel.Entities;

namespace ErtsModel.FakeSeeds.Factories
{
    static class FakeTournamentTeamFactory
    {
        public static TournamentTeam Create(Team team, Tournament tournament)
        {

            var seriesPlayed = Faker.RandomNumber.Next(0, 18);
            var seriesWon = Faker.RandomNumber.Next(0, seriesPlayed);
            var seriesLost = seriesPlayed - seriesWon;
            var gamesPlayed = Faker.RandomNumber.Next(seriesPlayed, 54);
            var gamesWon = Faker.RandomNumber.Next(0, gamesPlayed);
            var gamesLost = gamesPlayed - gamesWon;




            return new TournamentTeam
            {
                Team = team,
                Tournament = tournament,
                SeriesPlayed = seriesPlayed,
                SeriesWon = seriesWon,
                SeriesLost = seriesLost,
                GamesPlayed = gamesPlayed,
                GamesWon = gamesWon,
                GamesLost = gamesLost
            };
        }
    }
}