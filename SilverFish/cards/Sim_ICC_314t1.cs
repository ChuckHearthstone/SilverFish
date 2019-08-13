using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_314t1 : SimTemplate //* Frostmourne
    {
        // Deathrattle: Summon every minion killed by this weapon.

        CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.ICC_314t1);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(weapon, ownplay);
        }

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.callKid(CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_110t), m.zonepos - 1, m.own);//4/5 Baine Bloodhoof
        }
    }
}