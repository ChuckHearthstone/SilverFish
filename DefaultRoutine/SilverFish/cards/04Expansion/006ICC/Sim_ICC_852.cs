using HREngine.Bots;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_852: SimTemplate //* Prince Taldaram
    {
        // Battlecry: If your deck has no 3-Cost cards, transform into a 3/3 copy of a minion.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own && p.prozis.getDeckCardsForCost(3) == CardDB.CardIdEnum.None)
            {
                if (target != null)
                {
                    bool source = own.own;
                    own.setMinionToMinion(target);
                    own.own = source;
                    own.Attack = 3;
                    own.HealthPoints = 3;
                    own.maxHp = 3;
                    own.handcard.card.CardSimulation.onAuraStarts(p, own);
                }
            }
        }
    }
}