using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_132_PALADIN : SimTemplate //* The Silver Hand
	{
		//Hero Power. Summon two 1/1 Recruits.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.CS2_101t);//silverhandrecruit

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int place = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.CallKid(kid, place, ownplay, false);
            p.CallKid(kid, place, ownplay);
        }
	}
}