using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_OG_085 : SimTemplate //* Demented Frostcaller
	{
        //After you cast a spell, Freeze a random enemy character.

        public override void onCardIsGoingToBePlayed(Playfield p, CardDB.Card c, bool wasOwnCard, Minion triggerEffectMinion, Minion target, int choice)
        {
            if (triggerEffectMinion.own == wasOwnCard && c.type == CardDB.cardtype.SPELL)
            {
                Minion target2 = null;
                List<Minion> temp = (wasOwnCard) ? p.enemyMinions : p.ownMinions;
                if (temp.Count > 0) target2 = p.searchRandomMinion(temp, Playfield.searchmode.searchLowestHP);
                if (target2 == null) target2 = (wasOwnCard) ? p.enemyHero : p.ownHero;
                target2.frozen = true;
            }
        }
    }
}