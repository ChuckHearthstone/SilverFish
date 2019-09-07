using HREngine.Bots;

namespace SilverFish.cards._03Adventure._004KAR
{
	class Sim_KAR_091 : SimTemplate //* Ironforge Portal
	{
		//Gain 4 Armor. Summon a random 4-Cost minion.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionGetArmor(ownplay ? p.ownHero : p.enemyHero, 4);	
			
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.CallKid(p.getRandomCardForManaMinion(4), pos, ownplay);
		}
	}
}