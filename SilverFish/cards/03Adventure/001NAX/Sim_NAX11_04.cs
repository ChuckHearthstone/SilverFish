using HREngine.Bots;

namespace SilverFish.cards._03Adventure._001NAX
{
    class Sim_NAX11_04 : SimTemplate//* Mutating Injection
    {
	// Give a minion +4/+4 and Taunt.
	
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetBuffed(target, 4, 4);
            if (!target.taunt)
            {
                target.taunt = true;
                if (target.own) p.anzOwnTaunt++;
                else p.anzEnemyTaunt++;
            }
        }
    }
}
