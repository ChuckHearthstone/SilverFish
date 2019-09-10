using Chuck.SilverFish;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_414 : SimTemplate //grommashhellscream
	{

//    ansturm/, wutanfall:/ +6 angriff
        public override void onEnrageStart(Playfield p, Minion m)
        {
            m.Attack+=6;
        }

        public override void onEnrageStop(Playfield p, Minion m)
        {
            m.Attack-=6;
        }

	}
}