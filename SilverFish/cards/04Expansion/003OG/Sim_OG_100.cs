using HREngine.Bots;

namespace SilverFish.cards._04Expansion._003OG
{
    class Sim_OG_100 : SimTemplate //* Shadow Word: Horror
    {
        //Destroy all minions with 2 or less Attack.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            foreach (Minion m in p.enemyMinions)
            {
                if (m.Attack < 3) p.minionGetDestroyed(m);
            }
            foreach (Minion m in p.ownMinions)
            {
                if (m.Attack < 3) p.minionGetDestroyed(m);
            }
        }
    }
}