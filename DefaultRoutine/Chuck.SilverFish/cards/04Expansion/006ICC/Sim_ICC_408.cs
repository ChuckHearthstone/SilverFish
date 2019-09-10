using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_408: SimTemplate //* Val'kyr Soulclaimer
    {
        // Whenever this minion survives damage, summon a 2/2 Ghoul

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.ICC_900t); //Ghoul 2/2

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