using Chuck.SilverFish;
using System.Collections.Generic;
using SilverFish.Enums;

namespace SilverFish._cards._04Expansion.__011DAL
{
    /// <summary>
    /// Faceless Lackey
    /// 无面跟班
    /// </summary>
    class Sim_DAL_613 : SimTemplate
    {
        /// <summary>
        /// Battlecry: Summon a random 2-Cost minion.
        /// 战吼：随机召唤一个法力值消耗为2点的随从。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="m"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.CS2_121);
            List<Minion> list = (m.own) ? p.ownMinions : p.enemyMinions;
            int anz = list.Count;
            p.CallKid(kid, m.zonepos, m.own);
            if (anz < 7 && !list[m.zonepos].taunt)
            {
                list[m.zonepos].taunt = true;
                if (m.own)
                {
                    p.anzOwnTaunt++;
                }
                else
                {
                    p.anzEnemyTaunt++;
                }
            }
        }
    }
}