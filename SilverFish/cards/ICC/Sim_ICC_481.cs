using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_481: SimTemplate //* Thrall, Deathseer
    {
        // Battlecry: Transform your minions into random ones that cost (2) more.
        
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.setNewHeroPower(CardDB.cardIDEnum.ICC_481p, ownplay); // Transmute Spirit
            if (ownplay) p.ownHero.armor += 5;
            else p.enemyHero.armor += 5;

            List<Minion> temp = (ownplay) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                p.minionTransform(m, p.getRandomCardForManaMinion(m.handcard.card.cost + 2));
            }
        }
    }
}