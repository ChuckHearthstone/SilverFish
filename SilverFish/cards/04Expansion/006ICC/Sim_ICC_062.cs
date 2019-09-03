using HREngine.Bots;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_062: SimTemplate //* Mountainfire Armor
    {
        // Deathrattle: If it's your opponent's turn, gain 6 Armor.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (!p.isOwnTurn) p.minionGetArmor(m.own ? p.ownHero : p.enemyHero, 6);
        }
    }
}