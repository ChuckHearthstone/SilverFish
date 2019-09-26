using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._004CFM
{
    /// <summary>
    /// Blubber Baron
    /// 黑金大亨
    /// </summary>
	class Sim_CFM_064 : SimTemplate
	{
        /// <summary>
        /// Whenever you summon a Battlecry minion while this is in your hand, gain +1/+1.
        /// 每当你召唤一个具有战吼的随从时，便使这张牌在你手牌中时获得+1/+1。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="hc"></param>
        /// <param name="wasOwnCard"></param>
        /// <param name="triggerhc"></param>
        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Handmanager.Handcard triggerhc)
        {
            if (hc.card.battlecry && hc.card.type == CardType.Minion)
            {
                hc.addattack++;
                hc.addHp++;
            }
        }
    }
}