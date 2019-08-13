using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_043 : SimTemplate //Astral Communion
    {

        //   Gain 10 Mana Crystals. Discard your hand.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {

                if (p.ownMaxMana == 10)
                {
                    p.discardACard(ownplay, true);
                    p.drawACard(CardDB.cardIDEnum.CS2_013t, ownplay);
                }
                else
                {
                    p.discardACard(ownplay, true);
                    p.ownMaxMana = 10;
                }

            }
            else
            {
                if (p.enemyMaxMana == 10)
                {
                    p.discardACard(ownplay, true);
                    p.drawACard(CardDB.cardIDEnum.CS2_013t, ownplay);
                }
                else
                {
                    p.discardACard(ownplay, true);
                    p.enemyMaxMana = 10;
                }
            }
            
        }
    }
}