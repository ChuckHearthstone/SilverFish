using System.Collections.Generic;
using HREngine.Bots;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_GVG_043 : SimTemplate //Glaivezooka
    {

        //   Battlecry: Give a random friendly minion +1 Attack.

        CardDB.Card w = CardDB.Instance.getCardDataFromID(CardIdEnum.GVG_043);
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(w, ownplay);
            List<Minion> temp = (ownplay) ? p.ownMinions : p.enemyMinions;
            if (temp.Count <= 0) return;
            // Drew: Null check for searchRandomMinion.
            var found = p.searchRandomMinion(temp, searchmode.searchLowestAttack);
            if (found != null)
            {
                p.minionGetBuffed(found, 1, 0);
            }

        }

    }

}