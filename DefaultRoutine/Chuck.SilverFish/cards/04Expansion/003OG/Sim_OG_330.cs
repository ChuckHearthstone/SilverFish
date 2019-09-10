using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_330 : SimTemplate //* Undercity Huckster
	{
		//Deathrattle: Add a random class card to your hand (from your opponent's class).

		public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(CardName.unknown, m.own, true);
        }
    }
}