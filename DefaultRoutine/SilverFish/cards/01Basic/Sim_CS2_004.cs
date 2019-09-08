using HREngine.Bots;

namespace SilverFish.cards._01Basic
{
	class Sim_CS2_004 : SimTemplate //powerwordshield
	{

//    verleiht einem diener +2 leben.\nzieht eine karte.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionGetBuffed(target, 0, 2);
            p.drawACard(CardDB.cardName.unknown, ownplay);
		}

	}
}