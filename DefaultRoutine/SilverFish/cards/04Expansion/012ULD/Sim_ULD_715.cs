using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Plague of Madness
    /// 疯狂之灾祸
    /// </summary>
    public class Sim_ULD_715 : SimTemplate
    {
        /// <summary>
        /// Each player equips a 2/2 Knife with Poisonous.
        /// 每个玩家装备一把2/2并具有剧毒的刀。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardIdEnum.ULD_715t);

            p.equipWeapon(weapon, ownplay);
            p.equipWeapon(weapon, !ownplay);
        }
    }
}
