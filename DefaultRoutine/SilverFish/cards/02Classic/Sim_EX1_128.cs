using HREngine.Bots;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_128 : SimTemplate //conceal
	{

//    verleiht euren dienern bis zu eurem nächsten zug verstohlenheit/.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            if (ownplay)
            {
                foreach (Minion m in p.ownMinions)
                {
                    if (!m.stealth)
                    {
                        m.stealth = true;
                        m.conceal = true;
                    }
                }
            }
            else
            {
                foreach (Minion m in p.enemyMinions)
                {
                    if (!m.stealth)
                    {
                        m.stealth = true;
                        m.conceal = true;
                    }
                }
            }
		}

	}

}