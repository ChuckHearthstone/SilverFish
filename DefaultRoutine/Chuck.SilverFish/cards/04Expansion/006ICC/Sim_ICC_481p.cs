using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_481p: SimTemplate //* Transmute Spirit
    {
        // Hero Power: Transform a friendly minion into a random one that costs (1) more.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionTransform(target, p.getRandomCardForManaMinion(target.handcard.card.cost + 1));
        }
    }
}