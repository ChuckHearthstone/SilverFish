using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_018: SimTemplate //* Phantom Freebooter
    {
        // Battlecry: Gain stats equal to your weapon's.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.minionGetBuffed(own, 1, 1);
            if (own.own)
            {
                own.Attack += p.ownWeapon.Angr;
                own.HealthPoints += p.ownWeapon.Durability;
                own.maxHp += p.ownWeapon.Durability;
            }
            else
            {
                own.Attack += p.enemyWeapon.Angr;
                own.HealthPoints += p.enemyWeapon.Durability;
                own.maxHp += p.enemyWeapon.Durability;
            }
        }
    }
}
