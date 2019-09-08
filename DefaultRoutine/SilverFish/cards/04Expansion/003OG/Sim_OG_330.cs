using HREngine.Bots;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_330 : SimTemplate //* Undercity Huckster
	{
		//Deathrattle: Add a random class card to your hand (from your opponent's class).

		public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(CardDB.CardName.unknown, m.own, true);
        }
    }
}