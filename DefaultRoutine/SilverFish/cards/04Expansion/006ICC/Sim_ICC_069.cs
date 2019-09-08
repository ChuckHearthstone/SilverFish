using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_069: SimTemplate //* Ghastly Conjurer
    {
        // Battlecry: Add a 'Mirror Image' spell to your hand.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.drawACard(CardName.mirrorimage, own.own, true);
        }
    }
}