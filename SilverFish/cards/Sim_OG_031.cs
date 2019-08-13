using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_OG_031 : SimTemplate //* Hammer of Twilight
    {
        //Deathrattle: Summon a 4/2 Elemental.

        CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.OG_031);
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.OG_031a);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(weapon, ownplay);
        }

        public override void onDeathrattle(Playfield p, Minion m)
        {
            int pos = (m.own) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(kid, pos, m.own);
        }
    }
}