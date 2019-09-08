using System;
using HREngine.Bots;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Wispering Woods
    /// 精灵之森
    /// </summary>
    class Sim_GIL_553 : SimTemplate
    {
        /// <summary>
        /// Summon a 1/1 Wisp for each card in your hand.
        /// 你每有一张手牌，便召唤一个1/1的小精灵。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.CS2_231); //小精灵
            int posi = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            int wispNum = Math.Min(7 - posi, (ownplay) ? p.owncards.Count : p.enemyAnzCards);
            for (int i = 0; i < wispNum; i++)
            {
                p.CallKid(kid, posi, ownplay);
                posi++;
            }
        }
    }
}