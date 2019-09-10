using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_027 : SimTemplate //* Pyros
	{
		//Deathrattle: Return this to your hand as a 6/6 that costs (6).

        public override void onDeathrattle(Playfield p, Minion m)
        {
		    p.drawACard(CardIdEnum.UNG_027t2, m.own, true);
        }
	}
}