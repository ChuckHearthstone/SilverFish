using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._03Adventure._002BRM
{
	class Sim_BRM_006 : SimTemplate //* Imp Gang Boss
	{
		// Whenever this minion takes damage, summon a 1/1 Imp.

		CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.BRM_006t); //imp

        public override void onMinionGotDmgTrigger(Playfield p, Minion m, int anzOwnMinionsGotDmg, int anzEnemyMinionsGotDmg, int anzOwnHeroGotDmg, int anzEnemyHeroGotDmg)
        {
            if (m.anzGotDmg > 0)
            {
                int tmp = m.anzGotDmg;
                m.anzGotDmg = 0;
                for (int i = 0; i < tmp; i++)
                {
					int pos = m.zonepos;
					p.CallKid(kid, pos, m.own);
                }
            }
        }
	}
}