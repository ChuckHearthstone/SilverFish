using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._03Adventure._004KAR
{
	class Sim_KAR_094 : SimTemplate //* Deadly Fork
	{
		//Deathrattle: Add a 3/2 weapon to your hand.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(CardName.sharpfork, m.own, true);
        }
    }
}