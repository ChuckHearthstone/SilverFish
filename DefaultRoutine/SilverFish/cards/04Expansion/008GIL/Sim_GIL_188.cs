using HREngine.Bots;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Druid of the Scythe
    /// 镰刀德鲁伊
    /// </summary>
    public class Sim_GIL_188 : SimTemplate
    {
        /// <summary>
        /// Choose One - Transform into a 4/2 with Rush; or a 2/4 with Taunt.
        /// 抉择：将该随从变形成为4/2并具有突袭；或者将该随从变形成为2/4并具有嘲讽。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            CardDB.Card druidofthescythe42 = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.GIL_188t);
            CardDB.Card druidofthescythe24 = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.GIL_188t2);
            CardDB.Card druidofthescythe44 = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.GIL_188t3);
            if (p.ownFandralStaghelm > 0)
            {
                p.minionTransform(own, druidofthescythe44);
            }
            else
            {
                if (choice == 1)
                {
                    p.minionTransform(own, druidofthescythe42);
                }
                else if (choice == 2)
                {
                    p.minionTransform(own, druidofthescythe24);
                }
            }
        }
    }
}
