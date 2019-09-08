using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_940 : SimTemplate //* I Know a Guy
	{
		// Discover a Taunt minion.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardName.pompousthespian, ownplay, true);
        }
    }
}