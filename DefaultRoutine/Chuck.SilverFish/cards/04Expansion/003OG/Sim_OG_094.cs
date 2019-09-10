using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_094 : SimTemplate //* Power Word Tentacles
	{
		//Give a minion +2/+6.
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetBuffed(target, 2, 6);
        }
    }
}
