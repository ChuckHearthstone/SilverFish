using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_829t1 : SimTemplate //* Nether Portal
	{
		//Open a permanent portal that summons 3/2 Imps.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.UNG_829t2); //Nether Portal

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.CallKid(kid, pos, ownplay, false);
			p.evaluatePenality -= 15;
        }
    }
}