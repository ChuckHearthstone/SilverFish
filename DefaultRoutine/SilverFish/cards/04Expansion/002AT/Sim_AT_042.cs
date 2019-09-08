using HREngine.Bots;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_042 : SimTemplate //* Druid of the Saber
	{
		//Choose One - Charge or +1/+1 and Stealth.
        
        CardDB.Card cCharge = CardDB.Instance.getCardDataFromID(CardIdEnum.AT_042t);
        CardDB.Card cStealth = CardDB.Instance.getCardDataFromID(CardIdEnum.AT_042t2);
        CardDB.Card cTiger = CardDB.Instance.getCardDataFromID(CardIdEnum.OG_044c);
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (p.ownFandralStaghelm > 0)
            {
                p.minionTransform(own, cTiger);
            }
            else
            {
                if (choice == 1)
                {
                    p.minionTransform(own, cCharge);
                }
                if (choice == 2)
                {
                    p.minionTransform(own, cStealth);
                }
            }
		}
	}
}