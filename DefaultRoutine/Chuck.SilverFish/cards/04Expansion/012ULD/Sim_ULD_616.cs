using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Titanic Lackey
    /// 泰坦造物跟班
    /// </summary>
    public class Sim_ULD_616 : SimTemplate
    {
        /// <summary>
        /// Battlecry: Give a friendly minion +2 Health and Taunt.
        /// 战吼：使一个友方随从获得+2生命值和 嘲讽。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null)
            {
                p.minionGetBuffed(target, 0, 2);
                if (!target.taunt)
                {
                    target.taunt = true;
                    if (target.own)
                    {
                        p.anzOwnTaunt++;
                    }
                    else
                    {
                        p.anzEnemyTaunt++;
                    }
                }
            }
        }
    }
}