using HREngine.Bots;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_070 : SimTemplate //* Bladed Cultist
	{
		//Combo: Gain +1/+1.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{			
            if (p.cardsPlayedThisTurn > 0)
            {
                p.minionGetBuffed(own, 1, 1);
            }
		}
	}
}