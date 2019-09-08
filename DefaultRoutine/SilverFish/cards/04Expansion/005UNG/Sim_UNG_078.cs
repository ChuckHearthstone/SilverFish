using HREngine.Bots;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_078 : SimTemplate //* Tortollan Forager
	{
		//Battlecry: Add a random minion with 5 or more Attack to your hand.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.drawACard(CardDB.CardName.bootybaybodyguard, own.own, true);
        }
}
}