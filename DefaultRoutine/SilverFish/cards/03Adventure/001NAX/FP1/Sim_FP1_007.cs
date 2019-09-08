using HREngine.Bots;

namespace SilverFish.cards._03Adventure._001NAX.FP1
{
	class Sim_FP1_007 : SimTemplate //* nerubianegg
	{
        //todesröcheln:/ ruft einen neruber (4/4) herbei.
        CardDB.Card c = CardDB.Instance.getCardDataFromID(CardDB.CardIdEnum.FP1_007t);//nerubian
        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.CallKid(c, m.zonepos-1, m.own);
        }
	}
}