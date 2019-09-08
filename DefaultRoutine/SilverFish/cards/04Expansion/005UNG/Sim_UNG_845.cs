using HREngine.Bots;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_845 : SimTemplate //* Igneous Elemental
	{
		//Deathrattle: Add two 1/2 Elementals to your hand.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(CardIdEnum.UNG_809t1, m.own, true);
            p.drawACard(CardIdEnum.UNG_809t1, m.own, true);
        }
	}
}