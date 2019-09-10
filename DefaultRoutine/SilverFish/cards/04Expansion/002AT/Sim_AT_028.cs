using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._002AT
{
    class Sim_AT_028 : SimTemplate //* Shado-Pan Rider
    {
		//Combo: +3 Attack
			
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{			
            if (p.cardsPlayedThisTurn > 0)
            {
                p.minionGetBuffed(own, 3, 0);
            }
		}
	}
}