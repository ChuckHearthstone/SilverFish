using HREngine.Bots;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_572 : SimTemplate //ysera
	{

//    zieht am ende eures zuges eine traumkarte.

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                p.drawACard(CardDB.CardName.yseraawakens, turnEndOfOwner, true);
            }
        }

	}
}