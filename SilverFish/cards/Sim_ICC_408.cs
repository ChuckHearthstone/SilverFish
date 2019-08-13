using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_408: SimTemplate //* Val'kyr Soulclaimer
    {
        // Whenever this minion survives damage, summon a 2/2 Ghoul

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.ICC_900t); //Ghoul 2/2

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