using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_GVG_104 : SimTemplate //* Hobgoblin
    {
        //  Whenever you play a 1-Attack minion, give it +2/+2 

        public override void onMinionWasSummoned(Playfield p, Minion m, Minion summonedMinion)
        {
            if (summonedMinion.playedFromHand && summonedMinion.Attack == 1 && m.own == summonedMinion.own && m.entitiyID != summonedMinion.entitiyID)
            {
                p.minionGetBuffed(summonedMinion, 2, 2);
            }
        }
    }
}