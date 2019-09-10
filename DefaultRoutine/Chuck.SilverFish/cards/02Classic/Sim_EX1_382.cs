using Chuck.SilverFish;

namespace SilverFish.cards._02Classic
{
    class Sim_EX1_382 : SimTemplate //* Aldor Peacekeeper
	{
        //Battlecry: Change an enemy minion's Attack to 1.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if(target != null) p.minionSetAngrToX(target, 1);
		}

	}
}