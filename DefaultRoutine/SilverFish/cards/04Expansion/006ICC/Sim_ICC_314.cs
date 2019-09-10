using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_314 : SimTemplate //* The Lich King
    {
        // Taunt. At the end of your turn, add a random Death Knight card to your hand.

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (turnEndOfOwner == triggerEffectMinion.own)
            {
                if (triggerEffectMinion.own)
                {
                    p.drawACard(CardName.unknown, triggerEffectMinion.own, true);
                }
                else
                {
                    if (p.enemyAnzCards < 10) p.enemyAnzCards++;
                }
            }
        }
    }
}