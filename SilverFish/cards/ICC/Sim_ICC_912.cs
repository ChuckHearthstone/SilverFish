using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_912: SimTemplate //* Corpsetaker
    {
        // Battlecry: Gain Taunt if your deck has a Taunt minion. Repeat for Divine Shield, Lifesteal, Windfury.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                if (p.prozis.numDeckCardsByTag(GAME_TAGs.TAUNT) > 0)
                {
                    own.taunt = true;
                    p.anzOwnTaunt++;
                }
                if (p.prozis.numDeckCardsByTag(GAME_TAGs.DIVINE_SHIELD) > 0) own.divineshild = true;
                if (p.prozis.numDeckCardsByTag(GAME_TAGs.LIFESTEAL) > 0) own.lifesteal = true;
                if (p.prozis.numDeckCardsByTag(GAME_TAGs.WINDFURY) > 0) own.windfury = true;
            }
        }
    }
}