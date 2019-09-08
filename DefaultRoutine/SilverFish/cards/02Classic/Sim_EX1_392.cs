using System.Collections.Generic;
using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_392 : SimTemplate //battlerage
	{

//    zieht eine karte für jeden verletzten befreundeten charakter.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            List<Minion> temp = (ownplay)? p.ownMinions : p.enemyMinions;
            foreach (Minion mnn in temp )
            {
                if (mnn.wounded)
                {
                    p.drawACard(CardName.unknown, ownplay);
                }
            }
            if (ownplay && p.ownHero.HealthPoints < 30) p.drawACard(CardName.unknown, true);
            if (!ownplay && p.enemyHero.HealthPoints < 30) p.drawACard(CardName.unknown, false);

		}

	}
}