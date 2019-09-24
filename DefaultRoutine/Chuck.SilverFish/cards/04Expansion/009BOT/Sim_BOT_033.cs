using SilverFish.Enums;

namespace Chuck.SilverFish.cards._04Expansion._009BOT
{
    /// <summary>
    /// Bomb Toss
    /// 投掷炸弹
    /// </summary>
    public class Sim_BOT_033 : SimTemplate
    {
        /// <summary>
        /// Deal 2 damage. Summon a 0/2 Goblin Bomb.
        /// 造成2点伤害。召唤一个0/2的地精炸弹。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.BOT_031);

            int dmg = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            p.minionGetDamageOrHeal(target, dmg);

            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.CallKid(kid, pos, ownplay);
        }
    }
}