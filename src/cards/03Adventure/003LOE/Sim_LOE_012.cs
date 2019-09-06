using HREngine.Bots;

namespace SilverFish.cards._03Adventure._003LOE
{
	class Sim_LOE_012 : SimTemplate //* Tomb Pillager
	{
		//Deathrattle: Put a Coin into your hand.
		
        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(CardDB.cardName.thecoin, m.own);
        }
    }
}