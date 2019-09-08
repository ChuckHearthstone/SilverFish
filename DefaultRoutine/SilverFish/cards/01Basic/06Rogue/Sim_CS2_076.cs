using HREngine.Bots;

namespace SilverFish.cards._01Basic._06Rogue
{
    class Sim_CS2_076 : SimTemplate//Assassinate
    {

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetDestroyed(target);
        }

    }
}
