using HREngine.Bots;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_020 : SimTemplate //* Arcanologist
	{
		//Battlecry: Draw a Secret from your deck.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(CardDB.CardName.unknown, own.own);
		}
	}
}