using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_KAR_026 : SimTemplate //Protect the King!
    {
        // For each enemy minion, summon a 1/1 Pawn with Taunt.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.KAR_026t);//Pawn

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int anz = p.enemyMinions.Count;
            int posi = p.ownMinions.Count;

            for (int i = 0; i < anz; i++)
            {
                p.callKid(kid, posi, ownplay);
            }
        }
    }
}