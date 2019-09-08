using HREngine.Bots;

namespace SilverFish.cards._01Basic._01Druid
{
	class Sim_CS2_005 : SimTemplate //claw
	{

//    verleiht eurem helden +2 angriff in diesem zug und 2 rüstung.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            if (ownplay)
            {
                p.minionGetArmor(p.ownHero, 2);
                p.minionGetTempBuff(p.ownHero, 2, 0);
            }
            else
            {
                p.minionGetArmor(p.enemyHero, 2);
                p.minionGetTempBuff(p.enemyHero, 2, 0);
            }
		}

	}
}