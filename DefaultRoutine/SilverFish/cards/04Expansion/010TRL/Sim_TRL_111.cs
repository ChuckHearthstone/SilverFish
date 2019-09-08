using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_TRL_111 : SimTemplate //猎头者之斧
	
	//战吼：如果你控制一个野兽，便获得+1耐久度。
	{
        CardDB.Card card = CardDB.Instance.getCardDataFromID(CardIdEnum.TRL_111);

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
		    if (ownplay)
            {
                bool haspet = false;
                foreach (Minion m in p.ownMinions)
                {
                    if ((TAG_RACE)m.handcard.card.race == TAG_RACE.PET)
                    {
                        haspet = true;
                        break;
                    }
                }
                
				p.equipWeapon(card,ownplay);
				
                
                if (haspet) p.ownWeapon.Durability++;
            }
		   
	    }
	}
}