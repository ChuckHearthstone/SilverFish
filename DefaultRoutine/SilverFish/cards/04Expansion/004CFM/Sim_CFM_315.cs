using HREngine.Bots;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_315 : SimTemplate //* Alleycat
	{
		// Battlecry: Summon a 1/1 Cat.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.CFM_315t); //1/1 Cat

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            p.CallKid(kid, m.zonepos, m.own);
        }
    }
}