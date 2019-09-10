using Chuck.SilverFish;

namespace SilverFish.cards._03Adventure._003LOE
{
	class Sim_LOE_018 : SimTemplate //* Tunnel Trogg
	{
		//Whenether you Overloaded, gain +1 Attack per locked Mana Crystal.

        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (wasOwnCard == triggerEffectMinion.own && hc.card.overload > 0)
            {
                p.minionGetBuffed(triggerEffectMinion, hc.card.overload, 0);
            }
        }

    }
}