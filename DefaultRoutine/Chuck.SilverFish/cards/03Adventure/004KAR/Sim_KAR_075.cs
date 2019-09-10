using Chuck.SilverFish;

namespace SilverFish.cards._03Adventure._004KAR
{
	class Sim_KAR_075 : SimTemplate //* Moonglade Portal
	{
		//Restore 6 Health. Summon a random 6-Cost minion.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int heal = (ownplay) ? p.getSpellHeal(6) : p.getEnemySpellHeal(6);
            p.minionGetDamageOrHeal(target, -heal);
			
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;			
            p.CallKid(p.getRandomCardForManaMinion(6), pos, ownplay, false);
		}
	}
}