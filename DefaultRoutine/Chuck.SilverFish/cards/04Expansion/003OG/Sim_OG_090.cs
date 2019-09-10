using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_090 : SimTemplate //* Cabalist's Tome
	{
		//Add 3 random Mage spells to your hand.
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardName.frostbolt, ownplay, true);
            p.drawACard(CardName.frostnova, ownplay, true);
            p.drawACard(CardName.frostnova, ownplay, true);
        }
    }
}