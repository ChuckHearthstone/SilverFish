using System;
using System.Collections.Generic;
using NUnit.Framework;
using SilverFish.Enums;
using SilverFish.Helpers;

namespace SilverFish.Test
{
    [TestFixture]
    class RandomLackeyTest : TestBase
    {
        [Test]
        public void GetRandomLackey()
        {
            double count = 1000;
            Dictionary<CardIdEnum, int> dictionary = new Dictionary<CardIdEnum, int>();
            for (int i = 0; i < count; i++)
            {
                var cardId = LackeyHelper.Instance.GetRandomLackey();
                if (dictionary.ContainsKey(cardId))
                {
                    dictionary[cardId]++;
                }
                else
                {
                    dictionary[cardId] = 1;
                }
            }

            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key} probability is {item.Value/count:P}");
            }
        }
    }
}
