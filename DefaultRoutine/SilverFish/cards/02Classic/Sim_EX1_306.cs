using HREngine.Bots;

namespace SilverFish.cards._02Classic
{
    class Sim_EX1_306 : SimTemplate //* Succubus
	{
        // Battlecry: Discard a random card.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.discardCards(1, own.own);
		}
	}
}