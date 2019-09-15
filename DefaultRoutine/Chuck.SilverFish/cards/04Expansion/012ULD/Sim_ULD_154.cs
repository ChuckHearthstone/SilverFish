using SilverFish.Enums;

namespace Chuck.SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Hyena Alpha
    /// 土狼头领
    /// </summary>
    public class Sim_ULD_154 : SimTemplate
    {
        /// <summary>
        /// Battlecry: If you control a Secret, summon two 2/2 Hyenas.
        /// 战吼：如果你控制一个奥秘，便召唤两只2/2的土狼。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            CardDB.Card hyena = CardDB.Instance.getCardDataFromID(CardIdEnum.ULD_154t);

            int secretNum = (own.own) ? p.ownSecretsIDList.Count : p.enemySecretCount;
            if (secretNum > 0)
            {
                p.CallKid(hyena, own.zonepos - 1, own.own);
                p.CallKid(hyena, own.zonepos, own.own);
            }
        }
    }
}