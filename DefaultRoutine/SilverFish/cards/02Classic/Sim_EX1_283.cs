using HREngine.Bots;

namespace SilverFish.cards._02Classic
{
    class Sim_EX1_283 : SimTemplate //* Frost Elemental
	{
        //Battlecry: Freeze a character.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.minionGetFrozen(target);
		}
	}
}