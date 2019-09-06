using HREngine.Bots;

namespace SilverFish.cards._03Adventure._002BRM
{
    class Sim_BRM_012 : SimTemplate //* Fireguard Destroyer
    {
        // Battlecry: Gain 1-4 Attack. Overload: (1)

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
			if(m.own) p.minionGetBuffed(m, 2, 0);
            else p.minionGetBuffed(m, 3, 0);
            if (m.own) p.ueberladung++;
        }
    }
}