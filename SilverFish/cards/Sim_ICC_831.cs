using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_831: SimTemplate //* Bloodreaver Gul'dan
    {
        // Battlecry: Summon all friendly Demons that died this game.

        CardDB cdb = CardDB.Instance;
        CardDB.Card kid = null;

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.setNewHeroPower(CardDB.cardIDEnum.ICC_831p, ownplay); // Siphon Life
            if (ownplay) p.ownHero.armor += 5;
            else p.enemyHero.armor += 5;


            int pos = ownplay ? p.ownMinions.Count : p.enemyMinions.Count;
            int kids = 7 - pos;
            if (kids > 0)
            {
                p.callKid(CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_301), pos, ownplay); //Felguard Taunt
                kids--;

                if (kids > 0)
                {
                    foreach (KeyValuePair<CardDB.cardIDEnum, int> e in Probabilitymaker.Instance.ownCardsOut)
                    {
                        kid = cdb.getCardDataFromID(e.Key);
                        if ((TAG_RACE)kid.race == TAG_RACE.DEMON)
                        {
                            for (int i = 0; i < e.Value; i++)
                            {
                                p.callKid(kid, pos, ownplay);
                                kids--;
                                if (kids < 1) break;
                            }
                            if (kids < 1) break;
                        }
                    }
                }
            }
        }
    }
}