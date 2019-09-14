using Chuck.SilverFish;
using SilverFish.Helpers;

namespace SilverFish._cards._04Expansion._011DAL
{
    public class Sim_DAL_415 : SimTemplate
    {
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (p.cardsPlayedThisTurn >= 1)
            {
                var cardIdEnum = LackeyHelper.Instance.GetRandomLackey();
                p.drawACard(cardIdEnum, own.own, true);
                p.drawACard(cardIdEnum, own.own, true);
            }
        }
    }
}