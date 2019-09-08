using HREngine.Bots;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_320 : SimTemplate //baneofdoom
	{

//    fügt einem charakter $2 schaden zu. beschwört einen zufälligen dämon, wenn der schaden tödlich ist.
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.CS2_059);//bloodimp
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{


            int dmg = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);

            bool summondemon = false;

            if (!target.isHero && dmg >= target.HealthPoints && !target.divineshild && !target.immune)
            {
                summondemon = true;
            }

            p.minionGetDamageOrHeal(target, dmg);

            if (summondemon)
            {
                int posi = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
                
                if (target.own && ownplay) p.CallKid(kid, posi, ownplay);
                else p.CallKid(kid, posi, ownplay);
            }

		}

	}
}