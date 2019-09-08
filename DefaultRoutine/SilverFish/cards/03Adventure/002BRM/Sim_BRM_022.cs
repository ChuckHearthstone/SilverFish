using HREngine.Bots;

namespace SilverFish.cards._03Adventure._002BRM
{
	class Sim_BRM_022 : SimTemplate //* Dragon Egg
	{
		// Whenever this minion takes damage, summon a 2/1 Whelp.

		CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.CardIdEnum.BRM_022t); //Black Whelp

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