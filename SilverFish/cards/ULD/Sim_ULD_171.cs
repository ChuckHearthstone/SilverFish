using System.Linq;

namespace HREngine.Bots
{
    /// <summary>
    /// Totemic Surge
    /// 图腾潮涌
    /// </summary>
    public class Sim_ULD_171 : SimTemplate
    {
        /// <summary>
        /// Give your Totems +2_Attack.
        /// 使你的图腾获得+2攻击力。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var minions = ownplay ? p.ownMinions : p.enemyMinions;
            int totemEnumValue = (int) TAG_RACE.TOTEM;
            var totemMinions = minions.Where(x => x.handcard.card.race == totemEnumValue).ToList();
            totemMinions.ForEach(delegate (Minion totem)
            {
                p.minionGetBuffed(totem,2,0);
            });
        }
    }
}
