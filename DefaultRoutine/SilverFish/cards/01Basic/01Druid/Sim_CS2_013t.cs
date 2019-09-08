using HREngine.Bots;

namespace SilverFish.cards._01Basic._01Druid
{
	class Sim_CS2_013t : SimTemplate //excessmana
	{

//    zieht eine karte. i&gt;(ihr könnt nur 10 mana in eurer leiste haben.)/i&gt;
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.drawACard(CardDB.cardName.unknown, ownplay);
		}

	}
}