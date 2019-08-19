using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_830: SimTemplate //* Shadowreaper Anduin
    {
        // Battlecry: Destroy all minions with 5 or more Attack.
        
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.setNewHeroPower(CardDB.cardIDEnum.ICC_830p, ownplay); // Voidform
            if (ownplay) p.ownHero.armor += 5;
            else p.enemyHero.armor += 5;

            foreach (Minion m in p.enemyMinions)
            {
                if (m.Angr >= 5) p.minionGetDestroyed(m);
            }
            foreach (Minion m in p.ownMinions)
            {
                if (m.Angr >= 5) p.minionGetDestroyed(m);
            }
        }
    }
}