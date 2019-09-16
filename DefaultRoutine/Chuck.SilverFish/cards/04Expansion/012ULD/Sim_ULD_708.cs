using SilverFish.Enums;

namespace Chuck.SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Livewire Lance
    /// 电缆长枪
    /// </summary>
    public class Sim_ULD_708 : SimTemplate
    {
        /// <summary>
        /// After your Hero attacks, add a Lackey to your hand.
        /// 在你的英雄攻击后，将一张跟班牌置入你的手牌。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardIdEnum.ULD_708);
            p.equipWeapon(weapon, ownplay);
        }
    }
}