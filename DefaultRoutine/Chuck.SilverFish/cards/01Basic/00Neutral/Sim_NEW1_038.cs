using Chuck.SilverFish;

namespace SilverFish.cards._01Basic._00Neutral
{
    class Sim_NEW1_038 : SimTemplate//Gruul
    {
        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            p.minionGetBuffed(triggerEffectMinion, 1, 1);
        }
        

    }
}
