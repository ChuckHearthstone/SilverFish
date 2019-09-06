using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_DAL_739: SimTemplate //* Acherus Veteran
    {
        // 战吼：使一个友方随从获得+1攻击力和突袭。
        //备注：未赋予突袭

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null) p.minionGetBuffed(target, 1, 0);
        }
    }
}