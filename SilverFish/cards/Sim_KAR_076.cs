using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_KAR_076 : SimTemplate //Firelands Portal
    {
        // Deal $5 damage. Summon a random 5-Cost minion.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.DS1_055);//Darkscale Healer 4/5
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(5) : p.getEnemySpellDamageDamage(5);
            p.minionGetDamageOrHeal(target, dmg);
            
            int pos = p.ownMinions.Count;
            p.callKid(kid, pos, ownplay);
        }
    }
}