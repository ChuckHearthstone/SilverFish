using HREngine.Bots;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_221 : SimTemplate //* Leeching Poison
    {
        //Give your weapon Lifesteal.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay) p.ownWeapon.lifesteal = true;
            else p.enemyWeapon.lifesteal = true;
        }
    }
}