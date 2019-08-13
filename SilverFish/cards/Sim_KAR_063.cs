using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_KAR_063 : SimTemplate //Spirit Claws
    {
        // Has +2 Attack while you have Spell Damage.

        CardDB.Card w = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.KAR_063);
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(w, ownplay);
            if (p.spellpower > 0)
            {
                if (ownplay)
                {
                    p.ownWeaponAttack += 2;
                    p.minionGetBuffed(p.ownHero, 2, 0);
                    p.ownSpiritclaws = true;
                }
                else
                {
                    p.enemyWeaponAttack += 2;
                    p.minionGetBuffed(p.enemyHero, 2, 0);
                    p.enemySpiritclaws = true;
                }
            }
        }
        

        //more handled in Playfield.updateBoards()
    }
}