
using SilverFish.Enums;

namespace Chuck.SilverFish.cards._04Expansion._011DAL
{
    /// <summary>
    /// Unleash the Beast
	/// 猛兽出笼
    /// </summary>
    class Sim_DAL_378 : TwinSpell
    {
        CardDB.Card wyvern = CardDB.Instance.getCardDataFromID(CardIdEnum.DAL_378t1);
        /// <summary>
        /// Twinspell Summon a 5/5 Wyvern with Rush.
		/// 双生法术 召唤一只5/5并具有突袭的双足飞龙。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {       
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.CallKid(wyvern, pos, ownplay, false);

            TriggerTwinSpell(p, ownplay);
        }
    }

    class Sim_DAL_378ts : Sim_DAL_378
    {

    }
}