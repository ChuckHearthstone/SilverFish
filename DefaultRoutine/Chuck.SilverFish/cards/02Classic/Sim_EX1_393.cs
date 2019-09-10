using Chuck.SilverFish;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_393 : SimTemplate //amaniberserker
	{

//    wutanfall:/ +3 angriff

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