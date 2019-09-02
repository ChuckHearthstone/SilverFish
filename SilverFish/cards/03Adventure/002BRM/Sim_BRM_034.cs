using HREngine.Bots;

namespace SilverFish.cards._03Adventure._002BRM
{
    class Sim_BRM_034 : SimTemplate //* Blackwing Corruptor
    {
        // Battlecry: If you're holding a Dragon, deal 3 damage.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (target != null) p.minionGetDamageOrHeal(target, 3);
        }
    }
}