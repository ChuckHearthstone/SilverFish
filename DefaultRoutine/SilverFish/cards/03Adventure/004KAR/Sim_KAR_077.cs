using Chuck.SilverFish;

namespace SilverFish.cards._03Adventure._004KAR
{
	class Sim_KAR_077 : SimTemplate //* Silvermoon Portal
	{
		//Give a minion +2/+2. Summon a random 2-Cost minion.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionGetBuffed(target, 2, 2);
			
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.CallKid(p.getRandomCardForManaMinion(2), pos, ownplay);
		}
	}
}