using SilverFish.Enums;

namespace Chuck.SilverFish.cards._04Expansion._011DAL
{
    /// <summary>
    /// The Forest's Aid
	/// 森林的援助
    /// </summary>
    class Sim_DAL_256 : TwinSpell
    {
        CardDB.Card treant = CardDB.Instance.getCardDataFromID(CardIdEnum.DAL_256t2);
        /// <summary>
        /// Twinspell Summon five 2/2 Treants.
		/// 双生法术 召唤五个2/2的树人。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.CallKid(treant, pos, ownplay, false);
            p.CallKid(treant, pos, ownplay);
            p.CallKid(treant, pos, ownplay);
            p.CallKid(treant, pos, ownplay);
            p.CallKid(treant, pos, ownplay);

            TriggerTwinSpell(p, ownplay);
        }
    }

    class Sim_DAL_256ts : Sim_DAL_256
    {

    }
}