using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_851: SimTemplate //* Prince Keleseth
    {
        // Battlecry: If your deck has no 2-cost cards, give all minions in your deck +1/+1.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own && p.prozis.GetDeckCardsForCost(2) == CardIdEnum.None) p.evaluatePenality -= 20;
        }
    }
}