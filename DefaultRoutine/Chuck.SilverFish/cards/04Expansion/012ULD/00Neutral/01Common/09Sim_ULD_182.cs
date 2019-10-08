using System.Linq;

namespace Chuck.SilverFish.cards._04Expansion._012ULD._00Neutral._01Common
{
    /// <summary>
    /// Spitting Camel
    /// 乱喷的骆驼
    /// </summary>
    public class Sim_ULD_182 : SimTemplate
    {
        /// <summary>
        /// At the end of your turn, deal 1 damage to another random friendly minion.
        /// 在你的回合结束时，随机对另一个友方随从造成1点伤害。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="triggerEffectMinion"></param>
        /// <param name="turnEndOfOwner"></param>
        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                var minions = triggerEffectMinion.own ? p.ownMinions : p.enemyMinions;
                minions = minions.Where(x => x.entitiyID != triggerEffectMinion.entitiyID).ToList();
                var minimumHealthPoints = minions.Min(x => x.HealthPoints);
                var targetMinions = minions.Where(x => x.HealthPoints == minimumHealthPoints).ToList();
                if (targetMinions.Count >= 1)
                {
                    p.minionGetDamageOrHeal(targetMinions[0], 1);
                }
            }
        }
    }
}