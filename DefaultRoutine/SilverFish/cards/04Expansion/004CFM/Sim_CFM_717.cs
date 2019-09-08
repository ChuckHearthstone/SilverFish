using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._004CFM
{
    /// <summary>
    /// Jade Claws
    /// 青玉之爪
    /// </summary>
	public class Sim_CFM_717 : SimTemplate
	{
        
        CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardIdEnum.CFM_717);

        /// <summary>
        /// "LocStringEnUs": "<b>Battlecry:</b> Summon a{1} {0} <b>Jade Golem</b>.\n<b><b>Overload</b>:</b> (1)@<b>Battlecry:</b> Summon a <b>Jade Golem</b>.
        /// "LocStringZhCn": "<b>战吼：</b>召唤一个{0}的<b>青玉魔像</b>。\n<b>过载：</b>（1）@<b>战吼：</b>召唤一个<b>青玉魔像</b>。\n<b>过载：</b>（1）",
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(weapon, ownplay);

            int place = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.CallKid(p.getNextJadeGolem(ownplay), place, ownplay);
        }
    }
}