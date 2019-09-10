using Chuck.SilverFish;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_379 : SimTemplate //repentance
	{
//    geheimnis:/ wenn euer gegner einen diener ausspielt, wird dessen leben auf 1 verringert.

        public override void onSecretPlay(Playfield p, bool ownplay, Minion target, int number)
        {
            target.HealthPoints = 1;
            target.maxHp = 1;
            target.wounded = false;

        }

	}

}