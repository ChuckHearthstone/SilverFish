using HREngine.Bots;

namespace HREngine.Bots
{
    /// <summary>
    /// Earthen Might
    /// 大地之力
    /// </summary>
    public class Sim_GIL_586 : SimTemplate
    {
        /// <summary>
        /// "LocStringEnUs": "[x]Give a minion +2/+2.If it's an Elemental, adda random Elementalto your hand.",
        /// "LocStringZhCn": "使一个随从获得+2/+2。如果该随从是元素，则随机将一张元素牌置入你的手牌。",
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetBuffed(target, 2, 2);
            if ((TAG_RACE)target.handcard.card.race == TAG_RACE.ELEMENTAL) p.drawACard(CardDB.cardName.unknown, ownplay);
        }
    }
}