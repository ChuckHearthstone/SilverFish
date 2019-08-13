using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_405: SimTemplate //* Rotface
    {
        // Whenever this minion survives damage, summon a random Legendary minion.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_014);//King Mukla 5/5

        public override void onMinionGotDmgTrigger(Playfield p, Minion m, int anzOwnMinionsGotDmg, int anzEnemyMinionsGotDmg, int anzOwnHeroGotDmg, int anzEnemyHeroGotDmg)
        {
            if (m.anzGotDmg > 0 && m.Hp > 0)
            {
                int tmp = m.anzGotDmg;
                m.anzGotDmg = 0;
                for (int i = 0; i < tmp; i++)
                {
                    p.callKid(kid, m.zonepos, m.own);
                }
            }
        }
    }
}