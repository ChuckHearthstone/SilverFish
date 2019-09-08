using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_318 : SimTemplate //* Hogger, Doom of Elwynn
	{
		//Whenever this minion takes damage, summon a 2/2 Gnoll with Taunt.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.OG_318t);

        public override void onMinionGotDmgTrigger(Playfield p, Minion m, int anzOwnMinionsGotDmg, int anzEnemyMinionsGotDmg, int anzOwnHeroGotDmg, int anzEnemyHeroGotDmg)
        {
            if (m.anzGotDmg >= 1)
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