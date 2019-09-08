using HREngine.Bots;

namespace SilverFish.cards._01Basic
{
	class Sim_CS2_041 : SimTemplate //* ancestralhealing
	{

//    Restore a minion to full Health and give it Taunt.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionGetDamageOrHeal(target, -1000);
            if (!target.taunt)
            {
                target.taunt = true;
                if (target.own) p.anzOwnTaunt++;
                else p.anzEnemyTaunt++;
            }
		}

	}
}