using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_KAR_004 : SimTemplate //Cat Trick
    {
        // Secret: After your opponent casts a spell, summon a 4/2 Panther with Stealth.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.KAR_004a); // 4/2 Panther

        public override void onSecretPlay(Playfield p, bool ownplay, Minion attacker, Minion target, out int number)
        {
            number = 0;
            if (ownplay)
            {
                int pos = p.ownMinions.Count;
                p.callKid(kid, pos, true);
                if (p.ownMinions.Count >= 1)
                {
                    if (p.ownMinions[pos - 1].name == CardDB.cardName.catinahat)
                    {
                        number = p.ownMinions[pos - 1].entityID;
                    }
                }
            }
            else
            {
                int pos = p.enemyMinions.Count;
                p.callKid(kid, pos, false);

                if (p.enemyMinions.Count >= 1)
                {
                    if (p.enemyMinions[pos - 1].name == CardDB.cardName.catinahat)
                    {
                        number = p.enemyMinions[pos - 1].entityID;
                    }
                }
            }

        }
    }
}