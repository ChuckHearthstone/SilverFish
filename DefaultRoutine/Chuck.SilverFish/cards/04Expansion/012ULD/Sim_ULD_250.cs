using SilverFish.Enums;

namespace Chuck.SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Infested Goblin
    /// 招虫的地精
    /// </summary>
    public class Sim_ULD_250 : SimTemplate
    {
        /// <summary>
        /// Taunt Deathrattle: Add two 1/1 Scarabs with Taunt to your hand.
        /// 嘲讽，亡语：将两张1/1并具有嘲讽的“甲虫”置入你的手牌。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="m"></param>
        public override void onDeathrattle(Playfield p, Minion m)
        {
            CardDB.Card scarab = CardDB.Instance.getCardDataFromID(CardIdEnum.ULD_215t);//甲虫 Scarab

            p.drawACard(scarab.name, m.own, true);
            p.drawACard(scarab.name, m.own, true);
        }
    }
}