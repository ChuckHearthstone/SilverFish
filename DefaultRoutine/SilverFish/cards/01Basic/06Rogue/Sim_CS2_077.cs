using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._01Basic._06Rogue
{
	class Sim_CS2_077 : SimTemplate //sprint
	{

//    zieht 4 karten.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.drawACard(CardName.unknown, ownplay);
            p.drawACard(CardName.unknown, ownplay);
            p.drawACard(CardName.unknown, ownplay);
            p.drawACard(CardName.unknown, ownplay);
		}

	}
}