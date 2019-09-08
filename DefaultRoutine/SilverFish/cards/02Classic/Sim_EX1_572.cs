using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_572 : SimTemplate //ysera
	{

//    zieht am ende eures zuges eine traumkarte.

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                p.drawACard(CardName.yseraawakens, turnEndOfOwner, true);
            }
        }

	}
}