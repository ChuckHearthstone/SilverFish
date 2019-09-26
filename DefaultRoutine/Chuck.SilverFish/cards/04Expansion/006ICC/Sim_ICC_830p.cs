using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._006ICC
{
    /// <summary>
    /// Voidform
    /// 虚空形态
    /// </summary>
    class Sim_ICC_830p: SimTemplate
    {
        /// <summary>
        /// Hero Power Deal 2 damage.
        /// 英雄技能 造成2点伤害。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getHeroPowerDamage(2) : p.getEnemyHeroPowerDamage(2);
            p.minionGetDamageOrHeal(target, dmg);
        }

        /// <summary>
        /// After you play a card, refresh this.
        /// 在你使用一张牌后，复原你的英雄技能。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="hc"></param>
        /// <param name="ownplay"></param>
        /// <param name="triggerhc"></param>
        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool ownplay, Handmanager.Handcard triggerhc)
        {
            if (ownplay)
            {
                p.ownAbilityReady = true;
            }
            else
            {
                p.enemyAbilityReady = true;
            }
        }
    }
}