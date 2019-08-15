using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{

    public class Sim_GIL_530 : SimTemplate //阴燃电鳗
    {
        //<b>战吼：</b>如果你的牌库中只有法力值消耗为偶数的牌，造成2点伤害。
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target == null)
            {
                Triton.Common.LogUtilities.Logger.GetLoggerInstanceForType()
                    .ErrorFormat("[target is null in Sim_GIL_530 getBattlecryEffect]");
            }

            int dmg = 2;
            p.minionGetDamageOrHeal(target, dmg);
        }
    }

}