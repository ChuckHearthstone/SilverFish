using HREngine.Bots;

namespace SilverFish.cards._04Expansion._011DAL
{
    /// <summary>
    /// Underbelly Angler
    /// 下水道渔人
    /// </summary>
    public class Sim_DAL_049 : SimTemplate
    {
        public override void onCardWasPlayed(Playfield p, CardDB.Card c, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (wasOwnCard == triggerEffectMinion.own)
            {
                int murlocEnumValue = (int) TAG_RACE.MURLOC;
                if (triggerEffectMinion.handcard.card.race == murlocEnumValue)
                {
                    //Bluegill Warrior 蓝腮战士
                    p.drawACard(CardIdEnum.CS2_173, wasOwnCard, true);
                }
            }
        }
    }
}
