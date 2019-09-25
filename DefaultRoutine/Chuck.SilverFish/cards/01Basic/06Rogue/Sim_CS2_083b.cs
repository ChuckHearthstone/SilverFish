using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._01Basic._06Rogue
{
    /// <summary>
    /// Dagger Mastery
    /// 匕首精通
    /// </summary>
	class Sim_CS2_083b : SimTemplate
	{
        /// <summary>
        /// Hero Power Equip a 1/2 Dagger.
        /// 英雄技能 装备一把1/2的 匕首。
        /// </summary>
        CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardIdEnum.CS2_082);
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(weapon, ownplay);
        }

	}
}