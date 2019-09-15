using SilverFish.Enums;

namespace Chuck.SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Desert Spear
    /// 沙漠之矛
    /// </summary>
    public class Sim_ULD_430 : SimTemplate
    {
        /// <summary>
        /// After your hero attacks, summon a 1/1 Locust with Rush.
        /// 在你的英雄攻击后，召唤一只1/1并具有突袭的蝗虫。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardIdEnum.ULD_430);
            p.equipWeapon(weapon, ownplay);
        }
    }
}