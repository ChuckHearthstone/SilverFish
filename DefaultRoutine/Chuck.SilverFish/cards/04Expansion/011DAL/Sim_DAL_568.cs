namespace Chuck.SilverFish.cards._04Expansion._011DAL
{
    /// <summary>
    /// Lightforged Blessing
    /// 光铸祝福
    /// </summary>
    public class Sim_DAL_568 : TwinSpell
    {
        /// <summary>
        /// Twinspell Give a friendly minion Lifesteal.
        /// 双生法术 使一个友方随从获得吸血。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            target.lifesteal = true;

            TriggerTwinSpell(p, ownplay);
        }
    }

    public class Sim_DAL_568ts : Sim_DAL_568
    {

    }
}