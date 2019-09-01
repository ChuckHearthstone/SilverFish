using System.Collections.Generic;
using HREngine.Bots;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_010 : SimTemplate //* Ram Wrangler
	{
		//Battlecry: If you have a Beast, summon a random Beast.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                if ((TAG_RACE)m.handcard.card.race == TAG_RACE.PET)
                {
                    p.CallKid(CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_120), temp.Count, own.own);//river crocolisk
                    break;
                }
            }
        }
    }
}