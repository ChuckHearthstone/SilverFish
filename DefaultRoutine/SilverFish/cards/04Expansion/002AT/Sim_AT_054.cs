using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_054 : SimTemplate //* The Mistcaller
	{
		//Battlecry: Give all minions in your hand and deck +1/+1.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
			if (own.own)
			{
				foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.type == CardType.Minion)
                    {
                        hc.addattack++;
                        hc.addHp++;
                    }
                }
			}
		}
	}
}