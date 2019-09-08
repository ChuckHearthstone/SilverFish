using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_122 : SimTemplate //* Mukla, Tyrant of the Vale
	{
		//Battlecry: Add 2 Bananas to your hand.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(CardName.bananas, own.own, true);
            p.drawACard(CardName.bananas, own.own, true);
		}
	}
}