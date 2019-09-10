using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_915 : SimTemplate //* Crackling Razormaw
	{
		//Battlecry: Adapt a friendly Beast.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
			if (target != null) p.getBestAdapt(own);
        }
    }
}