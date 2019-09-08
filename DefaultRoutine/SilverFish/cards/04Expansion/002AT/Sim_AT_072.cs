using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_072 : SimTemplate //* Varian Wrynn
	{
		//Battlecry: Draw 3 cards. Put any minion you drew directly into the battlefield.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
			if (own.own)
			{
				int tmpCard = p.owncards.Count;
				p.drawACard(CardDB.CardName.unknown, own.own);
				if (tmpCard < 10)
				{
					p.owncards.RemoveRange(p.owncards.Count - 1, 1);
					p.owncarddraw--;
                    p.CallKid(CardDB.Instance.getCardDataFromID(CardIdEnum.CS2_120), p.ownMinions.Count, own.own, false);//river crocolisk
				}
				p.drawACard(CardDB.CardName.unknown, own.own);
				if (tmpCard < 10)
				{
					p.owncards.RemoveRange(p.owncards.Count - 1, 1);
					p.owncarddraw--;
                    p.CallKid(CardDB.Instance.getCardDataFromID(CardIdEnum.EX1_048), p.ownMinions.Count, own.own, false);//spellbreaker
				}
				p.drawACard(CardDB.CardName.unknown, own.own);
			}
		}
	}
}