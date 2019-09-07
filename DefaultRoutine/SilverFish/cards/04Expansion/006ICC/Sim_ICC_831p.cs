using HREngine.Bots;

namespace SilverFish.cards._04Expansion._006ICC
{
    /// <summary>
    /// Bloodreaver Gul'dan
    /// 鲜血掠夺者古尔丹
    /// </summary>
    public class Sim_ICC_831p : SimTemplate
    {
        /// <summary>
        /// Battlecry: Summon all friendly Demons that died this game.
        /// 战吼：召唤所有在本局对战中死亡的友方恶魔。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getHeroPowerDamage(3) : p.getEnemyHeroPowerDamage(3);

            int oldHp = target.HealthPoints;
            p.minionGetDamageOrHeal(target, dmg);
            if (oldHp > target.HealthPoints) p.applySpellLifesteal(oldHp - target.HealthPoints, ownplay);
        }
    }
}