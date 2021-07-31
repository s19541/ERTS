﻿using ErtsModel.Entities;

namespace ErtsModel.FakeSeeds.Factories
{
    static class FakeLeagueFactory
    {
        public static League Create()
        {
            return new League
            {
                Name = Faker.Company.Name(),
                ImageUrl = "https://cdn.dev.pandascore.co/images/league/image/4004/220px-LCL2020_logo.png",
                GameType = Enums.GameType.Lol,
                Url = "https://iberiancup.lvp.global/"
            };
        }
    }
}