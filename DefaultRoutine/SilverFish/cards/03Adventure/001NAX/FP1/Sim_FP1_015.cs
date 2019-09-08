using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._03Adventure._001NAX.FP1
{
	class Sim_FP1_015 : SimTemplate //* feugen
	{
        //Deathrattle: If Stalagg also died this game, summon Thaddius.

        CardDB.Card thaddius = CardDB.Instance.getCardDataFromID(CardIdEnum.FP1_014t);

        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (p.stalaggDead)
            {
                p.CallKid(thaddius, m.zonepos - 1, m.own);
            }
        }
	}
}