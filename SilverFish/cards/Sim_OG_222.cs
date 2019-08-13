using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_OG_222 : SimTemplate //* Rallying Blade
    {
        //Battlecry: Give +1/+1 to your minions with Divine Shield.

        CardDB.Card w = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.OG_222);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(w, ownplay);
            List<Minion> temp = (ownplay) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                if (m.divineshild) p.minionGetBuffed(m, 1, 1);
            }
        }
    }
}