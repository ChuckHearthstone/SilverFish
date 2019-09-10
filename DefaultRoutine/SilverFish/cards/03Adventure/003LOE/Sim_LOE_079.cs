using Chuck.SilverFish;

namespace SilverFish.cards._03Adventure._003LOE
{
	class Sim_LOE_079 : SimTemplate //* Elise Starseeker
	{
		//Battlecry: Shuffle the 'Map to the Golden Monkey' into your deck.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
			{
				p.ownDeckSize++;
				p.evaluatePenality -= 6;
			}
            else p.enemyDeckSize++;
        }
    }
}