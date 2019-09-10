using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_047t2 : SimTemplate //* Fatespinner on board 2x
    {
        // Deathrattle: Give all minions +2/+2, then deal 3 damage to them.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.allMinionOfASideGetBuffed(true, 2, 2);
            p.allMinionOfASideGetBuffed(false, 2, 2);
            p.allMinionsGetDamage(3);
        }
    }
}