using HREngine.Bots;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Emeriss
    /// 艾莫莉丝
    /// </summary>
    public class Sim_GIL_128 : SimTemplate
    {
        /// <summary>
        /// Battlecry: Double the Attack and Health of all minions in your hand.
        /// 战吼：使你手牌中所有随从牌的攻击力和生命值翻倍。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.type == CardDB.cardtype.MOB)
                    {
                        hc.addattack += hc.card.Attack;
                        hc.addHp += hc.card.Health;
                        p.anzOwnExtraAngrHp += (hc.card.Attack + hc.card.Health);
                    }
                }
            }
        }
    }
}
