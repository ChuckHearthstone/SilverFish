using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_080e : SimTemplate //* Fadeleaf Toxin
	{
		//Give a friendly minion Stealth until your next turn.
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            target.stealth = true;
            target.conceal = true;
        }
    }
}