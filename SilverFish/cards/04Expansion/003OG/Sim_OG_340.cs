using HREngine.Bots;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_340 : SimTemplate //* Soggoth the Slitherer
	{
		//Taunt. Can't be targeted by spells or Hero Powers.
		
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            own.cantBeTargetedBySpellsOrHeroPowers = true;
        }
	}
}