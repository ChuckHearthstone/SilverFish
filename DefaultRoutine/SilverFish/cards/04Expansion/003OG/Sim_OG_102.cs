using HREngine.Bots;

namespace SilverFish.cards._04Expansion._003OG
{
    class Sim_OG_102 : SimTemplate //* Darkspeaker
    {
        //Battlecry: Swap stats with a friendly minion.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target == null) return;

            int tmpHp = target.HealthPoints;
            int tmpMHp = target.maxHp;
            int tmpAngr = target.Attack;

            target.HealthPoints = own.HealthPoints;
            target.maxHp = own.maxHp;
            target.Attack = own.Attack;

            own.HealthPoints = tmpHp;
            own.maxHp= tmpMHp;
            own.Attack = tmpAngr;
        }
    }
}