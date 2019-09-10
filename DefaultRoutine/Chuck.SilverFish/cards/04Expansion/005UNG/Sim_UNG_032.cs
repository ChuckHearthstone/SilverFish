using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_032 : SimTemplate //* Crystalline Oracle
	{
		//Deathrattle: Copy a card from your opponent's deck and add it to your hand.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(CardName.unknown, m.own, true);
        }
	}
}