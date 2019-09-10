using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_151 : SimTemplate //* Tentacle of N'Zoth
	{
		//Deathrattle: Deal 1 damage to all minions.
        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.allMinionsGetDamage(1);
        }
	}
}