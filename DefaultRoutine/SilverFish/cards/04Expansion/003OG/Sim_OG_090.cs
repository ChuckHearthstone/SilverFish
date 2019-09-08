using HREngine.Bots;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_090 : SimTemplate //* Cabalist's Tome
	{
		//Add 3 random Mage spells to your hand.
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardDB.CardName.frostbolt, ownplay, true);
            p.drawACard(CardDB.CardName.frostnova, ownplay, true);
            p.drawACard(CardDB.CardName.frostnova, ownplay, true);
        }
    }
}