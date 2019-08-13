using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_EX1_178 : SimTemplate //* ancientofwar
    {
        //Choose One - +5 Attack; or +5 Health and Taunt.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (p.ownFandralStaghelm > 0 && own.own)
            {
                for (int iChoice = 1; iChoice < 3; iChoice++)
                {
                    PenalityManager.Instance.getChooseCard(own.handcard.card, choice).sim_card.onCardPlay(p, own.own, own, iChoice);
                }
            }
            else PenalityManager.Instance.getChooseCard(own.handcard.card, choice).sim_card.onCardPlay(p, own.own, own, choice);
        }
    }
}