using HREngine.Bots;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_058 : SimTemplate //* Razorpetal Lasher
	{
		//Battlecry: Add a Razorpetal to your hand that deals 1 damage.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.drawACard(CardIdEnum.UNG_057t1, own.own, true);
        }
	}
}