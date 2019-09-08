using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_941 : SimTemplate //* Primordial Glyph
	{
		//Discover a spell. Reduce its Cost by (2).

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardName.frostbolt, ownplay, true);
        }
    }
}