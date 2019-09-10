using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Blackwald Pixie
    /// 黑樟林树精
    /// </summary>
    public class Sim_GIL_561 : SimTemplate
    {
        /// <summary>
        /// "Battlecry: Refresh your Hero Power.",
        /// "战吼：复原你的英雄技能。",
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                p.anzUsedOwnHeroPower = 0;
                p.ownAbilityReady = true;
            }
            else
            {
                p.anzUsedEnemyHeroPower = 0;
                p.enemyAbilityReady = true;
            }
        }
    }
}

