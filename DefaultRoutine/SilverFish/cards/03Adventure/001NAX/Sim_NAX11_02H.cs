using HREngine.Bots;

namespace SilverFish.cards._03Adventure._001NAX
{
	class Sim_NAX11_02H : SimTemplate //* Poison Cloud
	{
		// Hero Power: Deal 2 damage to all enemies. If any die, summon a slime.
		
		CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.NAX11_03);//Fallout Slime

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getHeroPowerDamage(2) : p.getEnemyHeroPowerDamage(2);
            p.allMinionOfASideGetDamage(!ownplay, dmg);
			
            int place = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            foreach (Minion m in ownplay ? p.enemyMinions : p.ownMinions)
            {
				if (m.HealthPoints <= 0) p.CallKid(kid, place, ownplay);
			}
		}
	}
}