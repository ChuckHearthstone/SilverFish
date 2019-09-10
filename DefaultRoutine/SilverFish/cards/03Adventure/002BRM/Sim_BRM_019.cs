using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._03Adventure._002BRM
{
	class Sim_BRM_019 : SimTemplate //* Grim Patron
	{
		// Whenever this minion survives damage, summon another Grim Patron.

		CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.BRM_019);//Grim Patron

        public override void onMinionGotDmgTrigger(Playfield p, Minion m, int anzOwnMinionsGotDmg, int anzEnemyMinionsGotDmg, int anzOwnHeroGotDmg, int anzEnemyHeroGotDmg)
        {
            if (m.anzGotDmg > 0 && m.HealthPoints > 0)
            {
                int tmp = m.anzGotDmg;
                m.anzGotDmg = 0;
                for (int i = 0; i < tmp; i++)
                {
                    p.CallKid(kid, m.zonepos, m.own);
                }
            }
        }
	}
}