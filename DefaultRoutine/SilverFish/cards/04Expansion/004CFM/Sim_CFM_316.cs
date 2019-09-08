using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_316 : SimTemplate //* Rat Pack
	{
		// Deathrattle: Summon a number of 1/1 Rats equal to this minion's Attack.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.CFM_316t); //1/1 Rat

        public override void onDeathrattle(Playfield p, Minion m)
        {
            int anz = m.Attack;
            if (anz > 0)
            {
                p.CallKid(kid, m.zonepos - 1, m.own, false);
                anz--;                
                for (int i = 0; i < anz; i++)
                {
                    p.CallKid(kid, m.zonepos - 1, m.own);
                }
            }
        }
    }
}