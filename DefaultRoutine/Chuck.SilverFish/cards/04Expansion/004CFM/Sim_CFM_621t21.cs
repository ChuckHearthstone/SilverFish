using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_621t21 : SimTemplate //* Mystic Wool
	{
		// Transform a random enemy minion into a 1/1 Sheep.
		
		private CardDB.Card sheep = CardDB.Instance.getCardDataFromID(CardIdEnum.CFM_621_m5);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
			target = (ownplay) ? p.searchRandomMinion(p.enemyMinions, searchmode.searchLowestAttack) : p.searchRandomMinion(p.ownMinions, searchmode.searchLowestAttack);
			if (target != null) p.minionTransform(target, sheep);
        }
    }
}