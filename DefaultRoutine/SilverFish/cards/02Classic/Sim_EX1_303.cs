using HREngine.Bots;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_303 : SimTemplate //shadowflame
	{

//    vernichtet einen befreundeten diener und fügt allen feindlichen dienern schaden zu, der seinem angriff entspricht.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int damage1 = (ownplay) ? p.getSpellDamageDamage(target.Attack) : p.getEnemySpellDamageDamage(target.Attack);

            p.minionGetDestroyed(target);

            p.allMinionOfASideGetDamage(!ownplay, damage1);

		}

	}
}