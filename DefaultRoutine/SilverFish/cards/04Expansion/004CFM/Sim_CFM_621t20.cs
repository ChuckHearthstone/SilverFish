using HREngine.Bots;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_621t20 : SimTemplate //* Netherbloom
	{
		// Summon a 5/5 Demon.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.CFM_621_m2);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.CallKid(kid, pos, ownplay, false);
        }
    }
}