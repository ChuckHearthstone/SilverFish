using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_834h: SimTemplate //* Bladestorm
    {
        // Hero Power: Deal 1 damage to all minions.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getHeroPowerDamage(1) : p.getEnemyHeroPowerDamage(1);
            p.allMinionsGetDamage(dmg);
        }
    }
}