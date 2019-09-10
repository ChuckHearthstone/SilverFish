using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_131 : SimTemplate //* Twin Emperor Vek'lor
	{
		//Taunt Battlecry:If your C'Thun has at least 10 attack, summon another Emperor.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.OG_319);
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                if (p.anzOgOwnCThunAngrBonus + 6 > 9) p.CallKid(kid, own.zonepos, own.own);
                else p.evaluatePenality += 5;
            }
		}
	}
}