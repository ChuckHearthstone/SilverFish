using HREngine.Bots;

namespace SilverFish.cards._01Basic
{
    class Sim_CS2_226 : SimTemplate //* Frostwolf Warlord
	{
        // Battlecry: Gain +1/+1 for each other friendly minion on the battlefield.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            int buff = (own.own) ? p.ownMinions.Count - 1 : p.enemyMinions.Count - 1;
            p.minionGetBuffed(own, buff, buff);
		}
	}
}