using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_080b : SimTemplate //* Kingsblood Toxin
	{
		//Draw a card.
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardName.unknown, ownplay);
        }
    }
}
