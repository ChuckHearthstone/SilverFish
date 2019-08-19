using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_071: SimTemplate //* Light's Sorrow
    {
        // After a friendly minion loses Divine Shield, gain +1 Attack.
        // Handled in triggerAMinionLosesDivineShield()

        CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.ICC_071);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(weapon, ownplay);
        }
    }
}