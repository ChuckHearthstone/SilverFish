using HREngine.Bots;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_027t2 : SimTemplate //* Pyros
	{
		//Deathrattle: Return this to your hand as a 10/10 that costs (10).

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(CardIdEnum.UNG_027t4, m.own, true);
        }
	}
}