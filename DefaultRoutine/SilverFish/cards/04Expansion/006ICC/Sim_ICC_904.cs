using HREngine.Bots;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_904: SimTemplate //* Wicked Skeleton
    {
        // Battlecry: Gain +1/+1 for each minion that died this turn.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            int buff = (own.own) ? p.ownMinionsDiedTurn : p.enemyMinionsDiedTurn;
            p.minionGetBuffed(own, buff, buff);
        }
    }
}