using HREngine.Bots;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_283 : SimTemplate //* C'Thun's Chosen
	{
		//Divine Shield. Battlecry: Give your C'Thun +2/+2 (wherever it is).
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own) p.cthunGetBuffed(2, 2, 0);
		}
	}
}