using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_KAR_013 : SimTemplate //Purify
    {
        // Silence a friendly minion. Draw a card.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if(ownplay && target.own)
            {
                p.minionGetSilenced(target);
                p.drawACard(CardDB.cardIDEnum.None, ownplay);
            }
        }
    }
}