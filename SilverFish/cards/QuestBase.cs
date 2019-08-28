using System;
using NUnit.Framework;

namespace HREngine.Bots.Silverfish.Cards
{
    public class QuestBase : SimTemplate
    {
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (p.playactions.Count < 2)
            {
                p.evaluatePenality -= 30;
            }
        }
    }

    /// <summary>
    /// Making Mummies
    /// 制作木乃伊
    /// </summary>
    public class Sim_ULD_431 : SimTemplate
    {
        //<b>Quest:</b> Play 5 <b>Reborn</b>\nminions.\n<b>Reward:</b> Emperor Wraps.
        //<b>任务：</b>使用5张<b>复生</b>牌。<b>奖励：</b>帝王裹布。
    }

    [TestFixture]
    public class MainTest
    {
        [Test]
        public void Test1()
        {
            Sim_ULD_431 sim = new Sim_ULD_431();
            bool flag = sim.GetType().IsSubclassOf(typeof(SimTemplate));
            Console.WriteLine(flag);
        }
    }
}
