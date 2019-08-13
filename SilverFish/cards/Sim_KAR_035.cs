using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_KAR_035 : SimTemplate //* Priest of the Feast
    {
        //Whenever you cast a spell, restore 3 Health to your hero.
        
        public override void onCardIsGoingToBePlayed(Playfield p, CardDB.Card c, bool wasOwnCard, Minion triggerEffectMinion, Minion target, int choice)
        {
            if (triggerEffectMinion.own == wasOwnCard && c.type == CardDB.cardtype.SPELL)
            {
                int heal = (wasOwnCard) ? p.getMinionHeal(3) : p.getEnemyMinionHeal(3);
                p.minionGetDamageOrHeal(wasOwnCard ? p.ownHero : p.enemyHero, -heal);
            }
        }
    }
}