using System.Collections.Generic;
using HREngine.Bots;

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
                    p.drawACard(CardDB.cardName.unknown, ownplay);
                }
            }
            if (ownplay && p.ownHero.HealthPoints < 30) p.drawACard(CardDB.cardName.unknown, true);
            if (!ownplay && p.enemyHero.HealthPoints < 30) p.drawACard(CardDB.cardName.unknown, false);

		}

	}
}