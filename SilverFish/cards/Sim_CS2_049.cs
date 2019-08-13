using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_CS2_049 : SimTemplate // totemiccall
    {
        //Hero Power: Summon a random Totem.

        CardDB.Card searing = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_050);
        CardDB.Card healing = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.NEW1_009);
        CardDB.Card wrathofair = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_052);
        CardDB.Card stoneclaw = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_051);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            CardDB.Card kid;
            int otherTotems = 0;
            bool wrath = false;
            foreach (Minion m in (ownplay) ? p.ownMinions : p.enemyMinions)
            {
                switch (m.name)
                {
                    case CardDB.cardName.searingtotem: otherTotems++; continue;
                    case CardDB.cardName.stoneclawtotem: otherTotems++; continue;
                    case CardDB.cardName.healingtotem: otherTotems++; continue;
                    case CardDB.cardName.wrathofairtotem: wrath = true; continue;
                }
            }
            if (p.isLethalCheck)
            {
                if (otherTotems == 3 && !wrath) kid = wrathofair;
                else kid = healing;
            }
            else
            {
                if (!wrath) kid = wrathofair;
                else kid = searing;

                if (p.ownHeroHasDirectLethal()) kid = stoneclaw;
            }
            p.callKid(kid, pos, ownplay, false);
        }
    }

}