using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_832: SimTemplate //* Malfurion the Pestilent
    {
        // Choose One - Summon 2 Poisonous Spiders; or 2 Scarabs with Taunt.

        CardDB.Card kidSpider = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.ICC_832t3); //Frost Widow
        CardDB.Card kidScarab = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.ICC_832t4); //Scarab Beetle
        
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.setNewHeroPower(CardDB.cardIDEnum.ICC_832p, ownplay); // Plague Lord
            if (ownplay) p.ownHero.armor += 5;
            else p.enemyHero.armor += 5;

            if (choice == 1 || (p.ownFandralStaghelm > 0 && ownplay))
            {
                int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
                p.callKid(kidSpider, pos, ownplay);
                p.callKid(kidSpider, pos, ownplay);
            }
            if (choice == 2 || (p.ownFandralStaghelm > 0 && ownplay))
            {
                int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
                p.callKid(kidScarab, pos, ownplay);
                p.callKid(kidScarab, pos, ownplay);
            }
        }
    }
}