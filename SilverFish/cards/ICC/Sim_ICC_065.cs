using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_065: SimTemplate //* Bone Baron
    {
        // Deathrattle: Add two 1/1 Skeletons to your hand.
        
        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(CardDB.cardIDEnum.ICC_026t, m.own, true); //Skeleton 1/1
            p.drawACard(CardDB.cardIDEnum.ICC_026t, m.own, true);
        }
    }
}