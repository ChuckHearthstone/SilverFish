using HREngine.Bots;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_837 : SimTemplate //* Bring It On!
    {
        // Gain 10 Armor. Reduce the Cost of minions in your opponent's hand by (2)

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetArmor(ownplay ? p.ownHero : p.enemyHero, 10);
        }
    }
}