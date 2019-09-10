using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_922 : SimTemplate //* Explore Un'Goro
	{
		//Replace your deck with copies of "Discover a card."

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
			p.evaluatePenality -= 20;
        }
    }
}