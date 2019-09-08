using System;
using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_GVG_032 : SimTemplate //* Grove Tender
    {

        //    Choose One - Give each player a Mana Crystal; or Each player draws a card.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (choice == 1 || (p.ownFandralStaghelm > 0 && own.own))
            {
				p.mana = Math.Min(10, p.mana+1);
				p.ownMaxMana = Math.Min(10, p.ownMaxMana+1);
				p.enemyMaxMana = Math.Min(10, p.enemyMaxMana+1);
            }

            if (choice == 2 || (p.ownFandralStaghelm > 0 && own.own))
            {
                p.drawACard(CardName.unknown, true);
                p.drawACard(CardName.unknown, false);
            }
        }


    }

}