using System.Collections.Generic;
using HREngine.Bots;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_085 : SimTemplate //* Demented Frostcaller
	{
		//After you cast a spell, Freeze a random enemy character.
		
        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool ownplay, Minion m)
        {
            if (m.own == ownplay && hc.card.type == CardDB.CardType.SPELL)
            {
                Minion target = null;
                List<Minion> temp = (ownplay) ? p.enemyMinions : p.ownMinions;
                if (temp.Count > 0) target = p.searchRandomMinion(temp, searchmode.searchLowestHP);
                if (target == null) target = (ownplay) ? p.enemyHero : p.ownHero;
                p.minionGetFrozen(target);
            }
        }
    }
}