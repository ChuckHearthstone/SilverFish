using HREngine.Bots;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_096 : SimTemplate //* Twilight Darkmender
	{
		//Battlecry: If your C'Thun has at least 10 Attack, restore 10 Health to your hero.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                if (p.anzOgOwnCThunAngrBonus + 6 > 9) p.minionGetDamageOrHeal(p.ownHero, -p.getMinionHeal(10));
                else p.evaluatePenality += 6;
            }
		}
	}
}