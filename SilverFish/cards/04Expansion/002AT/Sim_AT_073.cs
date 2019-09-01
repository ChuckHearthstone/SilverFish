using HREngine.Bots;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_073 : SimTemplate //* Competitive spirit
	{
		//Secret: When your turn starts, give your minions +1/+1.

        public override void onSecretPlay(Playfield p, bool ownplay, int number)
        {
            p.allMinionOfASideGetBuffed(ownplay, 1, 1);
        }
    }
}