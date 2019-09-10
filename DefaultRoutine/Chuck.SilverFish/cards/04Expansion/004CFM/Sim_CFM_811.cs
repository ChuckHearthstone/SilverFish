using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_811 : SimTemplate //* Lunar Visions
	{
		// Draw 2 cards. Minions drawn costs (2) less.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardName.unknown, ownplay);
            p.drawACard(CardName.unknown, ownplay);
        }
    }
}