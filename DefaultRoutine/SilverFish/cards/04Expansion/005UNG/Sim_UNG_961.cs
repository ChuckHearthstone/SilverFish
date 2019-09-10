using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_961 : SimTemplate //* Adaptation
	{
		//Adapt a friendly minion.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.evaluatePenality -= 15;
		}
	}
}