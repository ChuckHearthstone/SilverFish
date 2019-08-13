using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_KAR_097t : SimTemplate //Atiesh
    {
        // After you cast a spell, summon a random minion of that Cost. Lose 1 Durability.

        public override void onCardIsGoingToBePlayed(Playfield p, CardDB.Card c, bool wasOwnCard, Minion triggerEffectMinion, Minion target, int choice)
        {
            if (triggerEffectMinion.own == wasOwnCard && c.type == CardDB.cardtype.SPELL)
            {
                if (wasOwnCard)
                {
                    if (p.ownWeaponDurability > 0)
                    {
                        p.ownWeaponDurability--;
                        p.callKid(p.getRandomCardForManaMinion(c.cost), p.ownMinions.Count, wasOwnCard);
                    }
                }
                else
                {
                    if (p.enemyWeaponDurability > 0)
                    {
                        p.enemyWeaponDurability--;
                        p.callKid(p.getRandomCardForManaMinion(c.cost), p.enemyMinions.Count, wasOwnCard);
                    }
                }
            }
        }
    }
}