namespace Chuck.SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Pharaoh's Blessing
    /// 法老祝福
    /// </summary>
    public class Sim_ULD_143 : SimTemplate
    {
        /// <summary>
        /// Give a minion +4/+4, Divine Shield, and Taunt.
        /// 使一个随从获得+4/+4，圣盾以及嘲讽。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetBuffed(target, 4, 4);
            target.DivineShield = true;
            if (!target.taunt)
            {
                target.taunt = true;
                if (target.own) p.anzOwnTaunt++;
                else p.anzEnemyTaunt++;
            }
        }
    }
}