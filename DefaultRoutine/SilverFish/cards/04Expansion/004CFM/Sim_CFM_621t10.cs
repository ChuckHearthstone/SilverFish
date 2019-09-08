using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_621t10 : SimTemplate //* Netherbloom
	{
		// Summon a 2/2 Demon.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.CFM_621_m4);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.CallKid(kid, pos, ownplay, false);
        }
    }
}