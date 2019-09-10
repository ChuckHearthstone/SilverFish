using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_807 : SimTemplate //* Auctionmaster Beardo
	{
		// After you cast a spell, refresh your Hero Power.

        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool ownplay, Minion m)
        {
            if (m.own == ownplay && hc.card.type == CardType.SPELL)
            {
                if (m.own)
                {
                    p.anzUsedOwnHeroPower = 0;
                    p.ownAbilityReady = true;
                }
                else
                {
                    p.anzUsedEnemyHeroPower = 0;
                    p.enemyAbilityReady = true;
                }
            }
        }
    }
}