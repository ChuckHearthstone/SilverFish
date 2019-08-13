using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_KAR_037 : SimTemplate //Avian Watcher
    {
        // Battlecry: If you control a Secret, gain +1/+1 and Taunt.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (((own.own) ? p.ownSecretsIDList.Count : p.enemySecretList.Count) >= 1)
            {
                p.minionGetBuffed(own, 1, 1);
                own.taunt = true;
            }
        }
    }
}