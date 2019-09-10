using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Cathedral Gargoyle
    /// 教堂石像兽
    /// </summary>
    public class Sim_GIL_635 : SimTemplate
    {
        /// <summary>
        /// Battlecry: If you're holding a Dragon, gain Taunt and Divine Shield.
        /// 战吼：如果你的手牌中有龙牌，则获得嘲讽和圣盾。
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
                    m.taunt = true;
                    m.DivineShield = true;
                    p.anzOwnTaunt++;
                }
            }
            else
            {
                if (p.enemyAnzCards >= 2)
                {
                    m.taunt = true;
                    m.DivineShield = true;
                    p.anzEnemyTaunt++;
                }
            }
        }
    }
}