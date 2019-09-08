using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_086 : SimTemplate //* Giant Anaconda
	{
		//Deathrattle: Summon a minion from your hand with 5 or more Attack.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (m.own)
            {
                foreach (Handmanager.Handcard hc in p.owncards)
                {
					if (hc.card.Attack + hc.addattack >= 5)
                    {
                        p.CallKid(hc.card, p.owncards.Count, m.own);
						p.removeCard(hc);
                        break;
                    }
                }
            }
            else p.CallKid(CardDB.Instance.getCardData(CardName.seagiant), p.enemyMinions.Count, m.own);
        }
	}
}