using ErtsModel.Entities;

namespace ErtsModel.FakeSeeds.Factories
{
    static class FakeLeagueFactory
    {
        public static League Create()
        {
            return new League
            {
                Name = Faker.Company.Name(),
                ImageUrl = "https://cdn.dev.pandascore.co/images/lol/champion/image/5b5006046d300b532887aa8c26e1df0c.png",
                GameType = Enums.GameType.Lol,
                Url = "https://iberiancup.lvp.global/"
            };
        }
    }
}