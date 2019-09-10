using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_002 : SimTemplate //* Volcanosaur
	{
		//Battlecry: Adapt, then Adapt.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
			p.getBestAdapt(own);
			p.getBestAdapt(own);
        }
    }
}