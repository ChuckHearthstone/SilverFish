using HREngine.Bots;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_323 : SimTemplate //* Polluted Hoarder
	{
		//Deathrattle: Draw a card.
		
        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(CardDB.cardName.unknown, m.own);
        }
    }
}