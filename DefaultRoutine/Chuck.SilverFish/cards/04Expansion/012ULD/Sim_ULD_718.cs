namespace Chuck.SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Plague of Death
    /// 死亡之灾祸
    /// </summary>
    public class Sim_ULD_718 : SimTemplate
    {
        /// <summary>
        /// Silence and destroy all minions.
        /// 沉默并消灭所有随从。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.allMinionsGetSilenced(ownplay);
            p.allMinionsGetSilenced(!ownplay);
            p.allMinionsGetDestroyed();
        }
    }
}