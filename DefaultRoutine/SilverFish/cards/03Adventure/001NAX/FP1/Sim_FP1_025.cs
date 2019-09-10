using Chuck.SilverFish;

namespace SilverFish.cards._03Adventure._001NAX.FP1
{
	class Sim_FP1_025 : SimTemplate //reincarnate
	{

//    vernichtet einen diener und bringt ihn dann mit vollem leben wieder auf das schlachtfeld zurück.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            bool own = target.own;
            int place = target.zonepos;
            CardDB.Card d = target.handcard.card;
            p.minionGetDestroyed(target);
            p.CallKid(d, place, own);
		}

	}
}