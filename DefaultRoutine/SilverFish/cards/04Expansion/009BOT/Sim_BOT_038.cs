using System.Collections.Generic;
using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._009BOT
{

    /// <summary>
    /// Fireworks Tech
    /// 烟火技师
    /// </summary>
    class Sim_BOT_038 : SimTemplate
    {
        /// <summary>
        /// "LocStringEnUs": "[x]<b>Battlecry:</b> Give a friendly\nMech +1/+1. If it has\n<b>Deathrattle</b>, trigger it."
        /// "LocStringZhCn": "<b>战吼：</b>使一个友方机械获得+1/+1。如果它具有<b>亡语</b>，则将其\n触发。"
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null)
            {
                var card = target.handcard.card;
                if (card.race == (int)TAG_RACE.MECHANICAL)
                {
                    p.minionGetBuffed(target, 1, 1);
                }

                if (card.deathrattle)
                {
                    p.doDeathrattles(new List<Minion> { target });
                }
            }
        }
    }
}
