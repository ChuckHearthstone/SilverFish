using HREngine.Bots;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_083 : SimTemplate //* Twilight Flamecaller
	{
		//Battlecry: Deal 1 damage to all enemy minions
		
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
			p.allMinionOfASideGetDamage(!own.own, 1);
        }
    }
}