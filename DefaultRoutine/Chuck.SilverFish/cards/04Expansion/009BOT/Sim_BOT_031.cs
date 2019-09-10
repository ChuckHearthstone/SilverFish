using System;
using System.Collections.Generic;
using System.Text;

namespace Chuck.SilverFish
{
    class Sim_BOT_031 : SimTemplate //地精炸弹
    {

        //    亡语：对敌方英雄造成2点伤害。
        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.minionGetDamageOrHeal(m.own ? p.enemyHero : p.ownHero, 2);
        }

    }
}