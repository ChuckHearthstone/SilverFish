using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_054: SimTemplate //* Spreading Plague
    {
        // Summon a 1/5 Scarab with Taunt. If your opponent has more minions, cast this again.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.ICC_832t4); //Scarab Beetle

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {
                do
                {
                    p.callKid(kid, p.ownMinions.Count, ownplay);
                }
                while (p.enemyMinions.Count > p.ownMinions.Count);
            }
        }
    }
}