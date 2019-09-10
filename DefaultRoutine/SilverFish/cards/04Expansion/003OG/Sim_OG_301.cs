using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_301 : SimTemplate //* Ancient Shieldbearer
	{
		//Battlecry: If your C'Thun has at least 10 Attack, gain 10 Armor
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                if (p.anzOgOwnCThunAngrBonus + 6 > 9) p.minionGetArmor(p.ownHero, 10);
                else p.evaluatePenality += 5;
            }
		}
	}
}