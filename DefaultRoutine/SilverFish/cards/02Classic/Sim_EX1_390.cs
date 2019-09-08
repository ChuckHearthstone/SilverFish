using HREngine.Bots;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_390 : SimTemplate //taurenwarrior
	{

//    spott/, wutanfall:/ +3 angriff

        public override void onEnrageStart(Playfield p, Minion m)
        {
            m.Attack += 3;
        }

        public override void onEnrageStop(Playfield p, Minion m)
        {
            m.Attack -= 3;
        }

	}
}