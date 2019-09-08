using HREngine.Bots;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_834 : SimTemplate //* Feeding Time
	{
		//Deal $3 damage to a minion. Summon three 1/1 Pterrordaxes.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.CardIdEnum.UNG_834t1);
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);
            p.minionGetDamageOrHeal(target, dmg);
			
			int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.CallKid(kid, pos, ownplay, false);
            p.CallKid(kid, pos, ownplay);
            p.CallKid(kid, pos, ownplay);
		}
	}
}