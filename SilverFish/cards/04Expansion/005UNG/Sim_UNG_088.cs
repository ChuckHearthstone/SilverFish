using HREngine.Bots;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_088 : SimTemplate //* Tortollan Primalist
	{
		//Battlecry: Discover a spell and cast it with random targets.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
			p.evaluatePenality -= 10;
        }
    }
}