using System;
using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._03Adventure._001NAX
{
    class Sim_NAX5_03 : SimTemplate //* Mindpocalypse
    {
        // Both players draw 2 cards and gain a Mana Crystal.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardName.unknown, true);
            p.drawACard(CardName.unknown, true);
            p.drawACard(CardName.unknown, false);
            p.drawACard(CardName.unknown, false);
			
			p.mana = Math.Min(10, p.mana+1);
			p.ownMaxMana = Math.Min(10, p.ownMaxMana+1);
			p.enemyMaxMana = Math.Min(10, p.enemyMaxMana+1);
        }
    }
}