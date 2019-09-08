using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._03Adventure._004KAR
{
	class Sim_KAR_089 : SimTemplate //* Malchezaar's Imp
	{
		//Whenever you discard a card, draw a card.

        public override bool onCardDicscard(Playfield p, Handmanager.Handcard hc, Minion own, int num, bool checkBonus)
        {
            if (own == null) return false;
            if (checkBonus) return false;
			
            p.drawACard(CardName.unknown, own.own);
            return false;
        }
    }
}