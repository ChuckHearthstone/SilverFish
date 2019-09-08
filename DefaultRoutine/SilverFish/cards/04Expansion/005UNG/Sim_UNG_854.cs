using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_854 : SimTemplate //* Free From Amber
	{
		//Discover a minion that costs (8) or more. Summon it.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            if (p.ownHeroHasDirectLethal()) p.CallKid(CardDB.Instance.getCardData(CardName.icehowl), pos, ownplay, false);
            else p.CallKid(CardDB.Instance.getCardData(CardName.frostgiant), pos, ownplay, false);
        }
    }
}