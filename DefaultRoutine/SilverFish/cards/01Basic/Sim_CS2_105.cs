using HREngine.Bots;

namespace SilverFish.cards._01Basic
{
    class Sim_CS2_105 : SimTemplate //heroicstrike
    {

        //    verleiht eurem helden +4 angriff in diesem zug.
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetTempBuff(ownplay ? p.ownHero : p.enemyHero, 4, 0);

        }

    }
}