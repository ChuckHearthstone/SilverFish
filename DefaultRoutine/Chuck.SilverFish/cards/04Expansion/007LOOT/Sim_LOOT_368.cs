using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._007LOOT
{
    /// <summary>
    /// Voidlord
    /// 虚空领主
    /// </summary>
    public class Sim_LOOT_368 : SimTemplate
    {
        /// <summary>
        /// "LocStringEnUs": "[x]<b>Taunt</b>\n <b>Deathrattle:</b> Summon three\n1/3 Demons with <b>Taunt</b>.",
        /// "LocStringZhCn": "<b>嘲讽，亡语：</b>\n召唤三个1/3并具有<b>嘲讽</b>的恶魔。",
        /// </summary>
        /// <param name="p"></param>
        /// <param name="m"></param>
        public override void onDeathrattle(Playfield p, Minion m)
        {
            var card = CardDB.Instance.getCardDataFromID(CardIdEnum.CS2_065);
            p.CallKid(card, m.zonepos - 1, m.own, true, true);
            p.CallKid(card, m.zonepos, m.own, true, true);
            p.CallKid(card, m.zonepos + 1, m.own, true, true);
        }
    }
}
