using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_112 : SimTemplate //* Master Jouster
	{
		//Battlecry : Reveal a minion in each deck. If yours costs more, gain Taunt and Divine Shield.
			
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
			own.DivineShield = true; // optimistic
            if (!own.taunt)
            {
                own.taunt = true;
                if (own.own) p.anzOwnTaunt++;
                else p.anzEnemyTaunt++;
            }
        }
	}
}