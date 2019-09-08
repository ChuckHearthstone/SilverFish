using HREngine.Bots;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Scaleworm
    /// 巨鳞蠕虫
    /// </summary>
    public class Sim_GIL_601 : SimTemplate
    {
        /// <summary>
        /// Battlecry: If you're holding a Dragon, gain +1 Attack and Rush.
        /// 战吼：如果你的手牌中有龙牌，便获得+1攻击力和突袭。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="m"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (m.own)
            {
                bool dragonInHand = false;
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if ((TAG_RACE)hc.card.race == TAG_RACE.DRAGON)
                    {
                        dragonInHand = true;
                        break;
                    }
                }
                if (dragonInHand)
                {
                    p.minionGetBuffed(m, 1, 0);
                    //p.minionGetRush(m);
                    //突袭机制未实装 minionGetRush获得突袭
                }
            }
            else
            {
                if (p.enemyAnzCards >= 2)
                {
                    p.minionGetBuffed(m, 1, 0);
                    //p.minionGetRush(m);
                    //突袭机制未实装 minionGetRush获得突袭
                }
            }
        }
    }
}
