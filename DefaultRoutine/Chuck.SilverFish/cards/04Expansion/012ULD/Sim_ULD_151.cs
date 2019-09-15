namespace Chuck.SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Ramkahen Wildtamer
    /// 拉穆卡恒驯兽师
    /// </summary>
    public class Sim_ULD_151 : SimTemplate
    {
        /// <summary>
        /// Battlecry: Copy a random Beast in your hand.
        /// 战吼：随机复制一张你手牌中的野兽牌。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                Handmanager.Handcard hc = p.searchRandomMinionInHand(p.owncards, searchmode.searchLowestCost, GAME_TAGs.CARDRACE, TAG_RACE.PET);
                if (hc != null) p.drawACard(hc.card.name, own.own, true);
            }
        }
    }
}