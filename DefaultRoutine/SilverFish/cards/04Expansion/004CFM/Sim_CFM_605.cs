using HREngine.Bots;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_605 : SimTemplate //* Drakonid Operative
	{
		// Battlecry: If you're holding a Dragon, Discover a card in your opponent's deck.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (m.own)
            {
                bool dragonInHand = false;
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if ((TAG_RACE)hc.card.race == TAG_RACE.DRAGON)
                    {
                        dragonInHand = true;
                        break;
                    }
                }
                if (dragonInHand)
                {
                    p.drawACard(CardDB.cardName.enchantedraven, m.own, true);
                }
            }
            else
            {
                if (p.enemyAnzCards >= 2)
                {
                    p.drawACard(CardDB.cardName.drakonidcrusher, m.own, true);
                }
            }
        }
    }
}