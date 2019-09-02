using System;
using HREngine.Bots;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_114 : SimTemplate //* Forbidden Ritual
	{
		//Spend all your Mana. Summon that many 1/1 Tentacles.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.OG_114a); //Icky Tentacle

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
			if (ownplay)
			{
				if (p.mana > 0)
                {
				    int pos = p.ownMinions.Count;
                    int anz = Math.Min(7 - pos, p.mana);
					p.CallKid(kid, pos, ownplay, false);
                    anz--;
                    for (int i = 0; i < anz; i++)
					{
						p.CallKid(kid, pos, ownplay);
					}
					p.mana = 0;
				}				
			}
		}
	}
}