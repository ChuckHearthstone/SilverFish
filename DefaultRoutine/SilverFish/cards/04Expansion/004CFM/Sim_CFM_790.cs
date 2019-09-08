using HREngine.Bots;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_790 : SimTemplate //* Dirty Rat
	{
		// Taunt. Battlecry: Your opponent summons a random minion from their hand.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.CardIdEnum.EX1_066); //acidicswampooze

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            int zonepos = (m.own) ? p.enemyMinions.Count : p.ownMinions.Count;
            p.CallKid(kid, zonepos, !m.own);
        }
    }
}