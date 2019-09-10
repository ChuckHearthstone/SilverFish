using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_223 : SimTemplate //* Divine Strength
	{
		//Give a minion +1/+2.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionGetBuffed(target, 1, 2);
		}
	}
}