using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_161 : SimTemplate //naturalize
	{

//    vernichtet einen diener. euer gegner zieht 2 karten.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionGetDestroyed(target);
            p.drawACard(CardName.unknown, !ownplay);
            p.drawACard(CardName.unknown, !ownplay);
		}

	}
}