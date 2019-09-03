using HREngine.Bots;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Cutthroat Buccaneer
    /// 刺喉海盗
    /// </summary>
    public class Sim_GIL_902 : SimTemplate
    {
        /// <summary>
        /// "LocStringEnUs": "Combo: Give your weapon +1 Attack.",
        /// "LocStringZhCn": "连击：使你的武器获得+1攻击力。",
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (p.cardsPlayedThisTurn > 0)
            {
                if (own.own)
                {
                    if (p.ownWeapon.Durability >= 1)
                    {
                        p.ownWeapon.Angr += 1;
                        p.minionGetBuffed(p.ownHero, 1, 0);
                    }
                }
                else
                {
                    if (p.enemyWeapon.Durability >= 1)
                    {
                        p.enemyWeapon.Angr += 1;
                        p.minionGetBuffed(p.enemyHero, 1, 0);
                    }
                }
                p.minionGetBuffed(own, 3, 0);
            }
        }
    }
}
