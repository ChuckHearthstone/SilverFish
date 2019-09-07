using HREngine.Bots;

namespace SilverFish.cards._03Adventure._004KAR
{
	class Sim_KAR_029 : SimTemplate //* Runic Egg
	{
		//Deathrattle: Draw a card.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(CardDB.cardName.unknown, m.own);
        }
	}
}