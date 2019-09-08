using System.Collections.Generic;
using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_GVG_080 : SimTemplate //* Druid of the Fang
    {
        //   Battlecry:If you have a Beast, transform this minion into a 7/7.
        CardDB.Card betterguy = CardDB.Instance.getCardDataFromID(CardIdEnum.GVG_080t);

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;
            bool hasbeast = false;
            foreach (Minion m in temp)
            {
                if ((TAG_RACE)m.handcard.card.race == TAG_RACE.PET)
                {
                    hasbeast = true;
                    break;
                }
            }
            if(hasbeast) p.minionTransform(own, betterguy);
        }
    }
}