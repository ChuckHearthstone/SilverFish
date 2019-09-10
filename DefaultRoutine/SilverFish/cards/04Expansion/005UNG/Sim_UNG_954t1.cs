using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_954t1 : SimTemplate //* Galvadon
	{
		//Battlecry: Adapt 5 times.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.minionGetBuffed(own, 6, 0);
            p.minionGetBuffed(own, 0, 3);
            own.taunt = true;
            own.DivineShield = true;
        }
    }
}