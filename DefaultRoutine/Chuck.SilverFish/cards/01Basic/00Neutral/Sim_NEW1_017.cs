using Chuck.SilverFish;

namespace SilverFish.cards._01Basic._00Neutral
{
    class Sim_NEW1_017 : SimTemplate//Hungry Crab
    {
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null)
            {
                p.minionGetDestroyed(target);
                p.minionGetBuffed(own, 2, 2);
            }
        } 
    }
}
