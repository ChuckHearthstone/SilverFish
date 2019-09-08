using HREngine.Bots;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_310 : SimTemplate //* Call in the Finishers
	{
		// Summon four 1/1 Murlocs.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.CFM_310t); //1/1 Murloc Razorgill

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;

            p.CallKid(kid, pos, ownplay, false);
            p.CallKid(kid, pos, ownplay);
            p.CallKid(kid, pos, ownplay);
            p.CallKid(kid, pos, ownplay);
        }
    }
}