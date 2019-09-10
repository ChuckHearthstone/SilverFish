using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_614 : SimTemplate //illidanstormrage
	{
        CardDB.Card d = CardDB.Instance.getCardDataFromID(CardIdEnum.EX1_614t);//flameofazzinoth
//    beschwört jedes mal eine flamme von azzinoth (2/1), wenn ihr eine karte ausspielt.

        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (wasOwnCard == triggerEffectMinion.own)
            {
                    p.CallKid(d, triggerEffectMinion.zonepos, triggerEffectMinion.own);

            }
        }

	}
}