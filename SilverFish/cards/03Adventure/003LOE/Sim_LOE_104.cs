using HREngine.Bots;

namespace SilverFish.cards._03Adventure._003LOE
{
	class Sim_LOE_104 : SimTemplate //* Entomb
	{
		//Choose an enemy minion. Shuffle it into your deck.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionReturnToDeck(target, ownplay);
		}
	}
}