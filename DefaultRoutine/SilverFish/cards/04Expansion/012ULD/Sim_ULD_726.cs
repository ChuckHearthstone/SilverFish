using HREngine.Bots;
using SilverFish.Enums;
using System.Collections.Generic;

namespace SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Ancient Mysteries
    /// 远古谜团
    /// </summary>
    public class Sim_ULD_726 : SimTemplate
    {
        /// <summary>
        /// Draw a Secret from your deck. It costs 0.
        /// 从你的牌库中抽一张奥秘牌。其法力值消耗为0点。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="m"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {
                CardDB.Card c;
                bool secretDrew = false;
                foreach (KeyValuePair<CardIdEnum, int> cid in p.prozis.turnDeck)
                {
                    c = CardDB.Instance.getCardDataFromID(cid.Key);
                    if (c.Secret)
                    {
                        p.drawACard(c.name, ownplay);
                        p.owncards[p.owncards.Count - 1].manacost = 0;
                        secretDrew = true;
                    }
                    if (secretDrew) break;
                }
            }
            else
            {
                p.drawACard(CardName.unknown, ownplay);
            }
        }
    }
}
