using HREngine.Bots;

namespace SilverFish.cards._03Adventure._004KAR
{
	class Sim_KAR_092 : SimTemplate //* Medivh's Valet
	{
		//Battlecry: If you control a Secret, deal 3 damage.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (target != null) p.minionGetDamageOrHeal(target, 3);
		}
	}
}