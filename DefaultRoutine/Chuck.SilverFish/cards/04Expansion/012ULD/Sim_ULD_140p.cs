using SilverFish.Enums;

namespace Chuck.SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Tome of Origination
    /// 源生魔典
    /// </summary>
    public class Sim_ULD_140p : SimTemplate
    {
        /// <summary>
        /// Hero Power Draw a card. It costs 0.
        /// 英雄技能 抽一张牌。其法力值消耗为 0点。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardName.unknown, ownplay);
            if (ownplay)
            {
                p.owncards[p.owncards.Count - 1].manacost = 0;
            }           
        }
    }
}