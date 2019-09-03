using HREngine.Bots;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Quartz Elemental
    /// 石英元素
    /// </summary>
    public class Sim_GIL_156 : SimTemplate
    {
        /// <summary>
        /// Can't attack while damaged.
        /// 受伤时无法攻击。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="m"></param>
        public override void onEnrageStart(Playfield p, Minion m)
        {
            if (m.own == own)
            {
                m.cantAttack = false;
                m.updateReadyness();
            }
        }
        public override void onEnrageStop(Playfield p, Minion m)
        {
            if (m.own == own)
            {
                m.cantAttack = true;
                m.updateReadyness();
            }
        }
    }
}
