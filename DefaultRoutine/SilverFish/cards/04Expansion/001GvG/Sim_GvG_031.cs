using HREngine.Bots;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_GVG_031 : SimTemplate //* Recycle
    {
        //   Shuffle an enemy minion into your opponent's deck.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionReturnToDeck(target, !ownplay);
		}
	}
}