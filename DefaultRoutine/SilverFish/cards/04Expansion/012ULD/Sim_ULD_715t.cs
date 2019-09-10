using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Plagued Knife
    /// 灾祸狂刀
    /// </summary>
    public class Sim_ULD_715t : SimTemplate
    {
        /// <summary>
        /// Poisonous
        /// 剧毒
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>      
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardIdEnum.ULD_715t);
            
            p.equipWeapon(weapon, ownplay);
        }
    }
}
