using HREngine.Bots;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_GVG_067 : SimTemplate //Stonesplinter Trogg
    {

        //   Whenever your opponent casts a spell, gain +1 Attack.

        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (hc.card.type == CardDB.CardType.SPELL && wasOwnCard != triggerEffectMinion.own)
            {
                p.minionGetBuffed(triggerEffectMinion, 1, 0);
            }
        }


    }

}