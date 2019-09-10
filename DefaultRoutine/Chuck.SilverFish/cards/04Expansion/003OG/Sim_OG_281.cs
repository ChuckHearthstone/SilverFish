using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_281 : SimTemplate //* Beckoner of Evil
	{
		//Battlecry: Give your C'Thun +2/+2 (wherever it is).
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (own.own)
            {
                p.cthunGetBuffed(2, 2, 0);
            }
		}
	}
}