using System.Collections.Generic;
using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._001GvG
{
    internal class Sim_GVG_059 : SimTemplate //Coghammer
    {
        //   Battlecry: Give a random friendly minion Divine Shield and Taunt;.
        private CardDB.Card w = CardDB.Instance.getCardDataFromID(CardIdEnum.GVG_059);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(w, ownplay);
            List<Minion> temp = (ownplay) ? p.ownMinions : p.enemyMinions;
            if (temp.Count <= 0) return;
            Minion m = p.searchRandomMinion(temp, searchmode.searchLowestHP);
            if (m != null)
            {
                m.DivineShield = true;
                if (!m.taunt)
                {
                    m.taunt = true;
                    if (m.own) p.anzOwnTaunt++;
                    else p.anzEnemyTaunt++;
                }
            }
        }
    }
}