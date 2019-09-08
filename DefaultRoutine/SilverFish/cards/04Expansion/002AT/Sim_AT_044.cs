using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_044 : SimTemplate //* Mulch
	{
		//Destroy a minion. Add a random minion to your opponent's hand.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
			p.minionGetDestroyed(target);
            p.drawACard(CardName.unknown, !ownplay, true);
        }
    }
}