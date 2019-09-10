using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_254 : SimTemplate //* Eater of Secrets
	{
		//Destroy all enemy Secrets. Gain +1/+1 for each.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            int buff = (own.own) ? p.enemySecretList.Count : p.ownSecretsIDList.Count;
            p.minionGetBuffed(own, buff, buff);
			if (own.own) p.enemySecretList.Clear();
            else p.ownSecretsIDList.Clear();
		}
	}
}