using HREngine.Bots;

namespace SilverFish.cards._01Basic._00Neutral
{
    class Sim_NEW1_018 : SimTemplate//bloodsail raider
    {
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
             own.Attack += p.ownWeapon.Angr;
        }

    }
}
