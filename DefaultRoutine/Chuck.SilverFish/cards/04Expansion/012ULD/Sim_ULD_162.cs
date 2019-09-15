using SilverFish.Enums;

namespace Chuck.SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// EVIL Recruiter
    /// 怪盗征募官
    /// </summary>
    public class Sim_ULD_162 : SimTemplate
    {
        /// <summary>
        /// Battlecry: Destroy a friendly Lackey to summon a 5/5 Demon.
        /// 战吼：消灭一个友方跟班，召唤一个5/5的恶魔。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null)
            {
                CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.ULD_162t);
                p.minionGetDestroyed(target);
                p.CallKid(kid, own.zonepos, own.own);
            }
        }
    }
}