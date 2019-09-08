using HREngine.Bots;

namespace SilverFish.cards._03Adventure._001NAX.FP1
{
	class Sim_FP1_031 : SimTemplate //baronrivendare
	{

//    die todesröcheln/-effekte eurer diener werden 2-mal ausgelöst.
        public override void onAuraStarts(Playfield p, Minion own)
		{
            if (own.own) p.ownBaronRivendare++;
            else p.enemyBaronRivendare++;
		}

        public override void onAuraEnds(Playfield p, Minion m)
        {
            if (m.own)
            {
                p.ownBaronRivendare--;
            }
            else
            {
                p.enemyBaronRivendare--;
            }
        }

	}
}