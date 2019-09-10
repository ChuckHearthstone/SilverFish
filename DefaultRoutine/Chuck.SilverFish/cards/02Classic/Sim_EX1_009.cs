using Chuck.SilverFish;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_009 : SimTemplate //angrychicken
	{

//    wutanfall:/ +5 angriff.
        public override void onEnrageStart(Playfield p, Minion m)
        {
            p.minionGetBuffed(m, 5, 0);
        }

        public override void  onEnrageStop(Playfield p, Minion m)
        {
            p.minionGetBuffed(m, -5, 0);
        }

	}
}