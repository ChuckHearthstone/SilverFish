using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_335 : SimTemplate //* Shifting Shade
	{
		//Deathrattle: Copy a card from your opponent's deck and add it to your hand.
		
        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(CardName.unknown, m.own, true);
        }
	}
}