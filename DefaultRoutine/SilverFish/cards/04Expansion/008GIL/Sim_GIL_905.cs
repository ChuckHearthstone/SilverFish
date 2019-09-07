using HREngine.Bots;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Carrion Drake
    /// 食腐飞龙
    /// </summary>
    public class Sim_GIL_905 : SimTemplate
    {
        /// <summary>
        /// Battlecry: If a minion died this turn, gain Poisonous.
        /// 战吼：如果在本回合中有一个随从死亡，获得剧毒。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            int isMinionsDiedTurn = (own.own) ? p.ownMinionsDiedTurn : p.enemyMinionsDiedTurn;
            if (isMinionsDiedTurn >= 1) own.poisonous = true;
        }
    }
}