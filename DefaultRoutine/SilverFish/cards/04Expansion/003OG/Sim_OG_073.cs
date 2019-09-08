using HREngine.Bots;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_073 : SimTemplate //* Thistle Tea
	{
		//Draw a card. Add 2 extra copies of it to your hand.
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardDB.CardName.unknown, ownplay);
            p.drawACard(CardDB.CardName.unknown, ownplay, true);
            p.drawACard(CardDB.CardName.unknown, ownplay, true);
        }
    }
}
