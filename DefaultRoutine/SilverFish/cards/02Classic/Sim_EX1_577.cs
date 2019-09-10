using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_577 : SimTemplate //* thebeast
	{
        //Deathrattle: Summon a 3/3 Finkle Einhorn for your opponent.

        CardDB.Card c = CardDB.Instance.getCardDataFromID(CardIdEnum.EX1_finkle);//finkleeinhorn
        public override void onDeathrattle(Playfield p, Minion m)
        {
            int pos = (m.own) ? p.enemyMinions.Count : p.ownMinions.Count;
            p.CallKid(c, pos, !m.own);
        }
	}
}