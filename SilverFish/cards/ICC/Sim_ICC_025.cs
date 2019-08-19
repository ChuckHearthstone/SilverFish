using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_025: SimTemplate //* Rattling Rascal
    {
        // Battlecry: Summon a 5/5 Skeleton. Deathrattle: Summon a 5/5 Skeleton for your opponent.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.NAX4_03H); //Skeleton 5/5

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            p.callKid(kid, m.zonepos, m.own);
        }

        public override void onDeathrattle(Playfield p, Minion m)
        {
            int pos = (m.own) ? p.enemyMinions.Count : p.ownMinions.Count;
            p.callKid(kid, pos, !m.own);
        }
    }
}