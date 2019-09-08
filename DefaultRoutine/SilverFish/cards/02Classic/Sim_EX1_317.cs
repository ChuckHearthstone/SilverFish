using HREngine.Bots;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_317 : SimTemplate //sensedemons
	{

//    fügt eurer hand zwei zufällige dämonen aus eurem deck hinzu.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.drawACard(CardDB.CardName.unknown, ownplay);
            p.drawACard(CardDB.CardName.unknown, ownplay);
		}

	}
}