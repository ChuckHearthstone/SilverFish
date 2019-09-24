using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._01Basic._04Paladin
{
    /// <summary>
    /// Reinforce
    /// 援军
    /// </summary>
	class Sim_CS2_101 : SimTemplate
	{
        /// <summary>
        /// Hero Power Summon a 1/1 Silver Hand Recruit.
        /// 英雄技能 召唤一个1/1的白银之手新兵。
        /// </summary>
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.CS2_101t);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.CallKid(kid, pos, ownplay, false);
        }

	}
}