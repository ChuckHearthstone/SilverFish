using System.IO;
using HREngine.Bots;
using NUnit.Framework;

namespace SilverFish.Test
{
    [TestFixture]
    public class AiTest : TestBase
    {
        [Test]
        public void Test()
        {
            //-mode: 0-all, 1-lethalcheck, 2-normal
            Ai ai = Ai.Instance;
            ai.autoTester(true, string.Empty, 0);

        }
    }
}