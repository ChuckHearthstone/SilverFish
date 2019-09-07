using HREngine.Bots;

namespace SilverFish.cards._04Expansion._002AT
{
    class Sim_AT_096 : SimTemplate //* Clockwork Knight
    {
		//Battlecry: Give a friendly Mech +1/+1.
		
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null) p.minionGetBuffed(target, 1, 1);
        }
    }
}