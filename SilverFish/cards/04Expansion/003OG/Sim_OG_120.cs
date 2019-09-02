using HREngine.Bots;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_120 : SimTemplate //* Anomalus
	{
		//Deathrattle: Deal 8 damage to all minions.
		
        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.allMinionsGetDamage(8);
        }
	}
}