using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._03Adventure._001NAX.FP1
{
	class Sim_FP1_014 : SimTemplate //* stalagg
	{
        //todesröcheln:/ ruft thaddius herbei, wenn feugen in diesem duell bereits gestorben ist.

        CardDB.Card thaddius = CardDB.Instance.getCardDataFromID(CardIdEnum.FP1_014t);

        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (p.feugenDead)
            {
                p.CallKid(thaddius, m.zonepos - 1, m.own);
            }
        }
	}
}