using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_042 : SimTemplate //* Druid of the Saber
    {
        //Choose One - Charge or +1/+1 and Stealth.

        CardDB.Card cCharge = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_042t);// 2/1 charge minion
        CardDB.Card cStealth = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_042t2);// 3/2 stealth minion
        CardDB.Card cTiger = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.OG_044c);// 3/2 stealth charge minion

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (p.anzOwnFandralStaghelm > 0 && own.own)
            {
                p.minionTransform(own, cTiger);
            }
            else if (choice == 1)
            {
                p.minionTransform(own, cCharge);
            }
            else if (choice == 2)
            {
                p.minionTransform(own, cStealth);
            }
        }
    }
}