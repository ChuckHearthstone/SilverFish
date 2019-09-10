using Chuck.SilverFish;

namespace SilverFish.cards._01Basic
{
    class Sim_CS2_181 : SimTemplate//Injured Blademaster
    {

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {

            p.minionGetDamageOrHeal(own, 4);
        }

    }
}
