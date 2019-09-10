using System;
using System.Collections.Generic;
using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.Helpers
{
    public class LackeyHelper
    {
        private readonly List<CardIdEnum> _lackeyList;

        private readonly Random _random;

        private LackeyHelper()
        {
            _random = new Random();

            _lackeyList = new List<CardIdEnum>
            {
                CardIdEnum.DAL_613,
                CardIdEnum.DAL_614,
                CardIdEnum.DAL_615,
                CardIdEnum.DAL_739,
                CardIdEnum.DAL_741,
                CardIdEnum.ULD_616,
            };
        }

        public static LackeyHelper Instance { get; } = new LackeyHelper();

        public CardIdEnum GetRandomLackey()
        {
            var index = _random.Next(0, _lackeyList.Count);
            return _lackeyList[index];
        }

    }
}
