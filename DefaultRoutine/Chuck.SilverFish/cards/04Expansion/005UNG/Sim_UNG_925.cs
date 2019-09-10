using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_925 : SimTemplate //* Ornery Direhorn
	{
		//Taunt. Battlecry: Adapt.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
			if (p.anzOwnElementalsLastTurn > 0 && own.own) p.getBestAdapt(own);
        }
    }
}