using HREngine.Bots;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_534 : SimTemplate //* savannahhighmane
	{
        //Deathrattle: Summon two 2/2 Hyenas.

        CardDB.Card c = CardDB.Instance.getCardDataFromID(CardDB.CardIdEnum.EX1_534t);//hyena
        
        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.CallKid(c, m.zonepos-1, m.own);
            p.CallKid(c, m.zonepos-1, m.own);
        }
	}
}