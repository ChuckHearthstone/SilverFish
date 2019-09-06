using HREngine.Bots;

namespace SilverFish.cards._03Adventure._003LOE
{
	class Sim_LOE_116 : SimTemplate //* Reliquary Seeker
	{
		//Battlecry: If you have 6 other minions, gain +4/+4.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
			int mCount = (m.own) ? p.ownMinions.Count : p.enemyMinions.Count;
			if (mCount > 6) p.minionGetBuffed(m, 4, 4);
        }
    }
}