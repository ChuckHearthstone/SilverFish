using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_577 : SimTemplate //* thebeast
	{
        //Deathrattle: Summon a 3/3 Finkle Einhorn for your opponent.

        CardDB.Card c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_finkle);//finkleeinhorn
        public override void onDeathrattle(Playfield p, Minion m)
        {
            int pos = (m.own) ? p.enemyMinions.Count : p.ownMinions.Count;
            p.callKid(c, pos, !m.own);
        }
	}
}