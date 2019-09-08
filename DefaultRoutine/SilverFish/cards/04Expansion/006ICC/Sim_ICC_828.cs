using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_828: SimTemplate //* Deathstalker Rexxar
    {
        // Battlecry: Deal 2 damage to all enemy minions.
        
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.setNewHeroPower(CardIdEnum.ICC_828p, ownplay); // Build-a-Beast
            if (ownplay) p.ownHero.armor += 5;
            else p.enemyHero.armor += 5;

            p.allMinionOfASideGetDamage(!ownplay, 2);
        }
    }
}