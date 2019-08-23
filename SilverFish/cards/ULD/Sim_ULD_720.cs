namespace HREngine.Bots
{
    /// <summary>
    /// Bloodsworn Mercenary
    /// 血誓雇佣兵
    /// </summary>
    public class Sim_ULD_720 : SimTemplate
    {
        /// <summary>
        /// "LocStringEnUs": "[x]<b>Battlecry</b>: Choose a\ndamaged friendly minion.\nSummon a copy of it.",
        /// "LocStringZhCn": "<b>战吼：</b>选择一个受伤的友方随从，召唤一个它的复制。",
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null && target.own && target.wounded)
            {
                int position = p.ownMinions.Count;
                p.callKid(own.handcard.card, position, true);
                p.ownMinions[position].setMinionToMinion(target);
            }
        }
    }
}
