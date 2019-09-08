using HREngine.Bots;

namespace SilverFish.cards._01Basic._00Neutral
{
	class Sim_PRO_001 : SimTemplate //elitetaurenchieftain
	{

//    kampfschrei:/ verleiht beiden spielern die macht des rock! (durch eine powerakkordkarte)
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(CardDB.CardName.roguesdoit, true, true);
            p.drawACard(CardDB.CardName.roguesdoit, false, true);
		}

	}
}