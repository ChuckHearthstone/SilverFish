namespace HREngine.Bots
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
                //Bluegill Warrior 蓝腮战士
                p.drawACard(CardDB.cardIDEnum.CS2_173, wasOwnCard, true);
            }
        }
    }
}
