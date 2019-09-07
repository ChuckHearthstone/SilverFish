using HREngine.Bots;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_125 : SimTemplate //* Icehowl
	{
		//Charge. Can't attack heroes.
        
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            own.cantAttackHeroes = true;
        }

        public override void onTurnEndsTrigger(Playfield p, Minion m, bool turnEndOfOwner)
        {
            if (m.own == turnEndOfOwner) m.cantAttackHeroes = true;
        }
    }
}