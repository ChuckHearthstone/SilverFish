using HREngine.Bots;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_643 : SimTemplate //* Hobart Grapplehammer
	{
		// Battlecry: Give all weapons in your hand and deck +1 Attack.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (m.own)
            {
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.type == CardDB.CardType.WEAPON) hc.addattack++;
                }
            }
        }
    }
}