using SilverFish.Enums;

namespace Chuck.SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Anubisath Warbringer
    /// 阿努比萨斯战争使者
    /// </summary>
    public class Sim_ULD_183 : SimTemplate
    {
        /// <summary>
        /// Deathrattle: Give all minions in your hand +3/+3.
        /// 亡语：使你手牌中的所有随从牌获得+3/+3。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="m"></param>
        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (m.own)
            {
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.type == CardType.Minion)
                    {
                        hc.addattack += 3;
                        hc.addHp += 3;
                        p.anzOwnExtraAngrHp += 6;
                    }
                }
            }
        }
    }
}