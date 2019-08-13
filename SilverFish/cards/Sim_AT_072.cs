using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_AT_072 : SimTemplate //* Varian Wrynn
	{
		//Battlecry: Draw 3 cards. Put any minion you drew directly into the battlefield.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
			if (own.own)
			{
				int tmpCard = p.owncards.Count;
				p.drawACard(CardDB.cardName.unknown, own.own);
				if (tmpCard < 10)
				{
					p.owncards.RemoveRange(p.owncards.Count - 1, 1);
					p.owncarddraw--;
                    p.callKid(CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_120), p.ownMinions.Count, own.own, false);//river crocolisk
				}
				p.drawACard(CardDB.cardName.unknown, own.own);
				if (tmpCard < 10)
				{
					p.owncards.RemoveRange(p.owncards.Count - 1, 1);
					p.owncarddraw--;
                    p.callKid(CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_048), p.ownMinions.Count, own.own, false);//spellbreaker
				}
				p.drawACard(CardDB.cardName.unknown, own.own);
			}
		}
	}
}