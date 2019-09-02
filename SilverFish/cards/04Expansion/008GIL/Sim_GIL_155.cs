using HREngine.Bots;

namespace HREngine.Bots
{
    /// <summary>
    /// Redband Wasp
    /// 赤环蜂
    /// </summary>
    public class Sim_GIL_155 : SimTemplate
    {
        /// <summary>
        /// "LocStringEnUs": "Rush Has +3 Attack while damaged.",
        /// "LocStringZhCn": "突袭 受伤时具有+3攻击力。",
        /// </summary>
        /// <param name="p"></param>
        /// <param name="m"></param>
        public override void onEnrageStart(Playfield p, Minion m)
        {
            m.Attack += 3;
        }

        public override void onEnrageStop(Playfield p, Minion m)
        {
            m.Attack -= 3;
        }
    }
}