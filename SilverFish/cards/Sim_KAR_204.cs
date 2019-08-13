using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_KAR_204 : SimTemplate //Onyx Bishop
    {
        // Battlecry: Summon a friendly minion that died this game.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS1_042); //Goldshire Footman
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own && Probabilitymaker.Instance.ownGraveYardCommonAttack >= 1)
            {
                int pos = p.ownMinions.Count;
                if (Probabilitymaker.Instance.ownGraveYardCommonTaunt == 1)
                {
                    p.callKid(kid, pos, true, true);
                    Minion m = p.ownMinions[p.ownMinions.Count - 1];
                    p.minionGetBuffed(m, Probabilitymaker.Instance.ownGraveYardCommonAttack - 1, Probabilitymaker.Instance.ownGraveYardCommonHP - 1);
                }
                else
                {
                    // create minion without taunt
                    p.callKid(kid, pos, true, true);
                    Minion m = p.ownMinions[p.ownMinions.Count - 1];
                    p.minionGetBuffed(m, Probabilitymaker.Instance.ownGraveYardCommonAttack - 1, Probabilitymaker.Instance.ownGraveYardCommonHP - 1);
                    m.taunt = false;
                }
            }


            if (!own.own && Probabilitymaker.Instance.enemyGraveYardCommonAttack >= 1)
            {
                int pos = p.enemyMinions.Count;
                if (Probabilitymaker.Instance.enemyGraveYardCommonTaunt == 1)
                {
                    p.callKid(kid, pos, false, true);
                    Minion m = p.enemyMinions[p.enemyMinions.Count - 1];
                    p.minionGetBuffed(m, Probabilitymaker.Instance.enemyGraveYardCommonAttack - 1, Probabilitymaker.Instance.enemyGraveYardCommonHP - 1);
                }
                else
                {
                    // create minion without taunt
                    p.callKid(kid, pos, false, true);
                    Minion m = p.enemyMinions[p.enemyMinions.Count - 1];
                    p.minionGetBuffed(m, Probabilitymaker.Instance.enemyGraveYardCommonAttack - 1, Probabilitymaker.Instance.enemyGraveYardCommonHP - 1);
                    m.taunt = false;
                }
            }
        }

    }
}