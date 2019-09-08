using HREngine.Bots;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_575 : SimTemplate //manatidetotem
	{

//    zieht am ende eures zuges eine karte.
        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (turnEndOfOwner == triggerEffectMinion.own)
            {
                p.drawACard(CardDB.CardName.unknown, turnEndOfOwner);
            }
        }

	}
}