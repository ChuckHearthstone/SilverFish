using Chuck.SilverFish;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_610 : SimTemplate //explosivetrap
	{
        //todo secret
//    geheimnis:/ wenn euer held angegriffen wird, erleiden alle feinde $2 schaden.
        public override void onSecretPlay(Playfield p, bool ownplay, int number)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            p.allMinionOfASideGetDamage(!ownplay, dmg);
        }

	}

}