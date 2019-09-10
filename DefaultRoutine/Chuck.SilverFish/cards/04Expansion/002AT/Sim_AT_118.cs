using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_118 : SimTemplate //* Grand Crusader
	{
		//Battlecry: Add a random Paladin card to your hand.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
			p.drawACard(CardName.unknown, m.own, true);
        }
    }
}