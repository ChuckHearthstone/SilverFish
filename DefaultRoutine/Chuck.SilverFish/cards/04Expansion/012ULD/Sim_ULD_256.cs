using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Into the Fray
    /// 投入战斗
    /// </summary>
    public class Sim_ULD_256 : SimTemplate
    {
        /// <summary>
        /// Give all Taunt minions in your hand +2/+2.
        /// 使你手牌中的所有嘲讽随从牌获得+2/+2。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.type == CardType.Minion && hc.card.tank)
                    {
                        hc.addattack += 2;
                        hc.addHp += 2;
                        p.anzOwnExtraAngrHp += 4;
                    }
                }
            }
        }
    }
}