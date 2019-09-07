using HREngine.Bots;

namespace SilverFish.cards._03Adventure._003LOE
{
	class Sim_LOE_105 : SimTemplate //* Explorer's Hat
	{
		//Give a minion +1/+1 and "Deathrattle: Add an Explorer's Hat to your hand."

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionGetBuffed(target, 1, 1);
            target.explorershat++;
		}
	}
}