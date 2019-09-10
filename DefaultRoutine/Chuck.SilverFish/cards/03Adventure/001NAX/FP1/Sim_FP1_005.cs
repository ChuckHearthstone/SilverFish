using Chuck.SilverFish;

namespace SilverFish.cards._03Adventure._001NAX.FP1
{
	class Sim_FP1_005 : SimTemplate //shadeofnaxxramas
	{

//    verstohlenheit/. erhält zu beginn eures zuges +1/+1.

        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (triggerEffectMinion.own == turnStartOfOwner)
            {
                p.minionGetBuffed(triggerEffectMinion,1,1);
            }
        }

	}
}