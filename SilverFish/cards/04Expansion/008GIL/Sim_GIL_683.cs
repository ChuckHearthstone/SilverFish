using HREngine.Bots;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Marsh Drake
    /// 沼泽飞龙
    /// </summary>
    public class Sim_GIL_683 : SimTemplate
    {
        /// <summary>
        /// "LocStringEnUs": "Battlecry: Summon a 2/1 Poisonous Drakeslayer for your opponent.",
        /// "LocStringZhCn": "战吼：为你的对手召唤一个2/1并具有剧毒的飞龙猎手。",
        /// </summary>
        /// </summary>
        /// <param name="p"></param>
        /// <param name="m"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.GIL_683t); 
        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            int pos = (m.own) ? p.enemyMinions.Count : p.ownMinions.Count;
            p.CallKid(kid, pos, !m.own);
        }

    }
}
