using HREngine.Bots;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_832 : SimTemplate //* Bloodbloom
	{
		//The next spell you cast this turn costs Health instead of Mana.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay) p.nextSpellThisTurnCostHealth = true;
        }
    }
}