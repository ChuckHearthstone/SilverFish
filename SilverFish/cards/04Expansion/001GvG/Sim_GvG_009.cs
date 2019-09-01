using HREngine.Bots;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_GVG_009 : SimTemplate //Shadowbomber
    {

        //   Battlecry: Deal 3 damage to each hero.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = 3;
            p.minionGetDamageOrHeal(p.enemyHero, dmg, true);
            p.minionGetDamageOrHeal(p.ownHero, dmg, true);
        }


    }

}