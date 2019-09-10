using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_833 : SimTemplate //* Lakkari Felhound
	{
		//Taunt. Battlecry: Discard two random cards.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.discardCards(2, own.own);
        }
    }
}