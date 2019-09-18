using SilverFish.Enums;

namespace Chuck.SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Mirage Blade
    /// 幻象之刃
    /// </summary>
    public class Sim_ULD_326t : SimTemplate
    {
        /// <summary>
        /// Your hero is Immune while attacking.
        /// 你的英雄在攻击时具有免疫。
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