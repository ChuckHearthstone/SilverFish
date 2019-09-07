using HREngine.Bots;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_GVG_068 : SimTemplate //Burly Rockjaw Trogg
    {

        //   Whenever your opponent casts a spell, gain +2 Attack.

        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (hc.card.type == CardDB.cardtype.SPELL && wasOwnCard != triggerEffectMinion.own)
            {
                p.minionGetBuffed(triggerEffectMinion, 2, 0);
            }
        }


    }

}