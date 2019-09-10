using System;
using System.IO;
using HearthDb;
using HearthDb.Enums;
using HREngine.Bots;
using NUnit.Framework;

namespace SilverFish.Test
{
    [TestFixture]
    class MurksparkEelTest : TestBase
    {
        [Test]
        public void Test()
        {

            var testFilePath = Path.Combine(Settings.Instance.BaseDirectory,
                @"SilverFish.Test\Data\MurksparkEelTest.txt");
            var data = File.ReadAllText(testFilePath);
            //Console.WriteLine(data);

            Ai ai = Ai.Instance;
            ai.autoTester(true, data, 0);

        }

        [Test]
        public void CardTest()
        {
            var card = Cards.All["GIL_530"];
            Console.WriteLine(card.Name);
            var error1 = card.Entity.GetReferencedTag(GameTag.ADDITIONAL_PLAY_REQS_1);
            Console.WriteLine(error1);
            var error2 = card.Entity.GetReferencedTag(GameTag.ADDITIONAL_PLAY_REQS_2);
            Console.WriteLine(error2);
        }
    }
}
