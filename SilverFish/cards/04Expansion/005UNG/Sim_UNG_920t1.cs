using HREngine.Bots;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_920t1 : SimTemplate //* Queen Carnassa
	{
		//Battlecry: Shuffle 15 Raptors into your deck.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (own.own)
			{
				p.ownDeckSize += 15;
				p.evaluatePenality -= 20;
			}
		}
	}
}