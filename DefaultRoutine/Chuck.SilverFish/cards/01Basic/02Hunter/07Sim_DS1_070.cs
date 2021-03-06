using Chuck.SilverFish;

namespace SilverFish.cards._01Basic._02Hunter
{
	class Sim_DS1_070 : SimTemplate //* houndmaster
	{
        //Battlecry: Give a friendly Beast +2/+2 and Taunt.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (target != null)
            {
                p.minionGetBuffed(target, 2, 2);
                if (!target.taunt)
                {
                    target.taunt = true;
                    if (target.own) p.anzOwnTaunt++;
                    else p.anzEnemyTaunt++;
                }
            }
		}
	}
}