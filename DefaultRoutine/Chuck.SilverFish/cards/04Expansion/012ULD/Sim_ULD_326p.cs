using SilverFish.Enums;

namespace Chuck.SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Ancient Blades
    /// 远古刀锋
    /// </summary>
    public class Sim_ULD_326p : SimTemplate
    {
        /// <summary>
        /// Hero Power Equip a 3/2 Blade with Immune while attacking.
        /// 英雄技能装备一把3/2的战刃，在攻击时具有免疫。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>   
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardIdEnum.ULD_326t);
            p.equipWeapon(weapon, ownplay);
        }
    }
}