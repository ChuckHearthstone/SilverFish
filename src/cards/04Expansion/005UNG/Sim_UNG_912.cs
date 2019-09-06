using HREngine.Bots;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_912 : SimTemplate //* Jeweled Macaw
	{
		//Battlecry: Add a random Beast to your hand.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.drawACard(CardDB.cardName.rivercrocolisk, own.own, true);
        }
}
}