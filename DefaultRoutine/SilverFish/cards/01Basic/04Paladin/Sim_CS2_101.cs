using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._01Basic._04Paladin
{
	class Sim_CS2_101 : SimTemplate //* reinforce
	{
        //Hero Power: Summon a 1/1 Silver Hand Recruit.
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.CS2_101t);//silverhandrecruit

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.CallKid(kid, pos, ownplay, false);
        }

	}
}