using HREngine.Bots;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_GVG_003 : SimTemplate //Unstable Portal
    {

        //    Add a random minion to your hand. It costs (3) less.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardDB.CardName.unknown, ownplay, true);
        }

    }

}