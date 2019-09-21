using SilverFish.Enums;

namespace Chuck.SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Hidden Oasis
    /// 隐秘绿洲
    /// </summary>
    public class Sim_ULD_135 : SimTemplate
    {
        /// <summary>
        /// Choose One - Summon a 6/6 Ancient with Taunt; or Restore 12 Health.
        /// 抉择：召唤一棵6/6并具有嘲讽的古树；或恢复12点生命值。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            CardDB.Card ancient = CardDB.Instance.getCardDataFromID(CardIdEnum.ULD_135at);
            if (choice == 1 || (p.ownFandralStaghelm > 0 && ownplay))
            {
                int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
                p.CallKid(ancient, pos, ownplay, false);
            }

            if (choice == 2 || (target != null && p.ownFandralStaghelm > 0 && ownplay))
            {
                int heal = (ownplay) ? p.getSpellHeal(12) : p.getEnemySpellHeal(12);
                p.minionGetDamageOrHeal(target, -heal);
            }
        }
    }
}