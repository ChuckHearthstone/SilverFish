using HREngine.Bots;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_080c : SimTemplate //* Bloodthistle Toxin
	{
        //Return a friendly minion to your hand. It costs (2) less.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionReturnToHand(target, ownplay, -2);
		}
	}
}