using Chuck.SilverFish;

namespace SilverFish.cards._02Classic
{
    class Sim_EX1_016 : SimTemplate //* Sylvanas Windrunner
	{
        //Deathrattle: Take control of a random enemy minion.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            Minion target;
            if (m.own)
            {
                target = p.searchRandomMinion(p.enemyMinions, searchmode.searchLowestHP);
            }
            else
            {
                target = p.searchRandomMinion(p.ownMinions, searchmode.searchHighestHP);
                if (p.isOwnTurn && target != null && target.Ready) p.evaluatePenality += 5;
            }
            if (target != null) p.minionGetControlled(target, m.own, false);
        }
	}
}