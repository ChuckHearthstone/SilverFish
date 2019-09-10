using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_009 : SimTemplate //* Ravasaur Runt
	{
		//Battlecry: If you control at least 2 other minions, Adapt.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            int num = (own.own) ? p.ownMinions.Count : p.enemyMinions.Count;
			if (num > 1) p.getBestAdapt(own);
        }
    }
}