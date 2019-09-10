using Chuck.SilverFish;

namespace SilverFish.cards._02Classic
{
    class Sim_EX1_310 : SimTemplate //* Doomguard
	{
        // Charge. Battlecry: Discard two random cards.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.discardCards(2, own.own);
		}
	}
}