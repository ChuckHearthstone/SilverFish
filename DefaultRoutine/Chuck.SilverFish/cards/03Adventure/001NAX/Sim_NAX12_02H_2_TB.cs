using Chuck.SilverFish;

namespace SilverFish.cards._03Adventure._001NAX
{
	class Sim_NAX12_02H_2_TB : SimTemplate //* Decimate
	{
		// Hero Power: Change the Health of enemy minions to 1.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            foreach (Minion m in ownplay ? p.enemyMinions : p.ownMinions)
            {
                p.minionSetLifetoX(m, 1);
            }
		}
	}
}