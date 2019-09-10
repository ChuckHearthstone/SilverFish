using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_198 : SimTemplate //* Forbidden Healing
	{
		//Spend all your Mana. Heal for double the mana you spent.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
			if (ownplay)
			{
				p.minionGetDamageOrHeal(target, -p.getSpellHeal(2 * p.mana));
				p.mana = 0;
			}
			else p.minionGetDamageOrHeal(target, -p.getSpellHeal(2 * p.enemyMaxMana));
		}
	}
}