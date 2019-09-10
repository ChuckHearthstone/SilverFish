using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_218: SimTemplate //* Howlfiend
    {
        // Whenever this minion takes damage, discard a random card.

        public override void onMinionGotDmgTrigger(Playfield p, Minion m, int anzOwnMinionsGotDmg, int anzEnemyMinionsGotDmg, int anzOwnHeroGotDmg, int anzEnemyHeroGotDmg)
        {
            if (m.anzGotDmg > 0) p.discardCards(m.anzGotDmg, m.own);
        }
    }
}
