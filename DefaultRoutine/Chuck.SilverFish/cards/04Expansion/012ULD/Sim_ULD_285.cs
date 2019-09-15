using SilverFish.Enums;

namespace Chuck.SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Hooked Scimitar
    /// 钩镰弯刀
    /// </summary>
    public class Sim_ULD_285 : SimTemplate
    {
        /// <summary>
        /// Combo: Gain +2 Attack.
        /// 连击：获得+2攻击力。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardIdEnum.ULD_285);
            p.equipWeapon(weapon, ownplay);
            if (ownplay)
            {
                if (p.cardsPlayedThisTurn >= 1)
                {
                    p.ownWeapon.Angr += 2;
                    p.minionGetBuffed(p.ownHero, 2, 0);
                }
            }
            else
            {
                if (p.cardsPlayedThisTurn >= 1)
                {
                    p.enemyWeapon.Angr += 2;
                    p.minionGetBuffed(p.enemyHero, 2, 0);
                }
            }
        }
    }
}