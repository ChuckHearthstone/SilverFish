using HREngine.Bots;

namespace SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Arcane Flakmage
    /// 对空奥术法师
    /// </summary>
    public class Sim_ULD_240 : SimTemplate
    {
        /// <summary>
        /// After you play a Secret, deal 2 damage to all enemy minions.
        /// 在你使用一张奥秘牌后，对所有敌方随从造成2点伤害。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="hc"></param>
        /// <param name="ownplay"></param>
        /// <param name="m"></param>
        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool ownplay, Minion m)
        {
            if (hc.card.Secret && ownplay == m.own)
            {
                p.allMinionOfASideGetDamage(!m.own, 2);
            }
        }
    }
}
