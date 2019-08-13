using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_041 : SimTemplate //* Dark Wispers
    {
        //   Choose One - Summon 5 Wisps; or Give a minion +5/+5 and Taunt.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_231);
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (choice == 1 || (p.ownFandralStaghelm > 0 && ownplay))
            {
                for (int i = 0; i < 5; i++)
                {
                    int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
                    p.callKid(kid, pos, ownplay);
                }
            }
            if (choice == 2 || (p.ownFandralStaghelm > 0 && ownplay))
            {
                if (target != null)
                {
                    p.minionGetBuffed(target, 5, 5);
                    if (!target.taunt)
                    {
                        target.taunt = true;
                        if (target.own) p.anzOwnTaunt++;
                        else p.anzEnemyTaunt++;
                    }
                }
            }
        }
    }

}