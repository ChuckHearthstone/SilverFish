using System;
using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._03Adventure._001NAX
{
	class Sim_NAX9_04 : SimTemplate //* Sir Zeliek
	{
        // Your hero is Immune.

        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.ownHero.immune = true;
                if (p.ownWeapon.name == CardName.runeblade && p.anzOwnHorsemen < 1)
                {
                    int bonus = (p.ownWeapon.card.cardIDenum == CardIdEnum.NAX9_05H) ? 6 : 3;
                    p.minionGetBuffed(p.ownHero, -1 * Math.Min(bonus, p.ownWeapon.Angr- 1), 0);
                    p.ownWeapon.Angr= Math.Min(1, p.ownWeapon.Angr- bonus);
                }
                p.anzOwnHorsemen++;
            }
            else
            {
                p.enemyHero.immune = true;
                if (p.enemyWeapon.name == CardName.runeblade && p.anzEnemyHorsemen < 1)
                {
                    int bonus = (p.enemyWeapon.card.cardIDenum == CardIdEnum.NAX9_05H) ? 6 : 3;
                    p.minionGetBuffed(p.enemyHero, -1 * Math.Min(bonus, p.enemyWeapon.Angr - 1), 0);
                    p.enemyWeapon.Angr = Math.Min(1, p.enemyWeapon.Angr - bonus);
                }
                p.anzEnemyHorsemen++;
            }
        }

        public override void onAuraEnds(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.anzOwnHorsemen--;
                if (p.anzOwnHorsemen < 1)
                {
                    p.ownHero.immune = false;
                    if (p.ownWeapon.name == CardName.runeblade)
                    {
                        int bonus = (p.ownWeapon.card.cardIDenum == CardIdEnum.NAX9_05H) ? 6 : 3;
                        p.minionGetBuffed(p.ownHero, bonus, 0);
                        p.ownWeapon.Angr+= bonus;
                    }
                }
            }
            else
            {
                p.anzEnemyHorsemen--;
                if (p.anzEnemyHorsemen < 1)
                {
                    p.enemyHero.immune = false;
                    if (p.enemyWeapon.name == CardName.runeblade)
                    {
                        int bonus = (p.enemyWeapon.card.cardIDenum == CardIdEnum.NAX9_05H) ? 6 : 3;
                        p.minionGetBuffed(p.enemyHero, bonus, 0);
                        p.enemyWeapon.Angr += bonus;
                    }
                }
            }
        }
    }
}