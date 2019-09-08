using HREngine.Bots;

namespace SilverFish.cards._03Adventure._001NAX.FP1
{
	class Sim_FP1_009 : SimTemplate //* deathlord
	{
        //Taunt. Deathrattle: Your opponent puts a minion from their deck into the battlefield.
        CardDB.Card c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_612);//kirintormage

        public override void onDeathrattle(Playfield p, Minion m)
        {
            int place = (m.own) ? p.enemyMinions.Count : p.ownMinions.Count;
            p.CallKid(c, place, !m.own, false);
        }
	}
}