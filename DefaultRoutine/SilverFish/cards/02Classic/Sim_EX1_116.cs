using HREngine.Bots;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_116 : SimTemplate //leeroyjenkins
	{
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.EX1_116t);//whelp
//    ansturm/. kampfschrei:/ ruft zwei welplinge (1/1) für euren gegner herbei.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{

            int pos = (own.own) ? p.enemyMinions.Count : p.ownMinions.Count;
            p.CallKid(kid, pos, !own.own);
            p.CallKid(kid, pos, !own.own);
		}
	}
}