using HREngine.Bots;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_GVG_083 : SimTemplate //Upgraded Repair Bot
    {

        //   Battlecry:&lt;/b&gt; Give a friendly Mech +4 Health.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null)
            {
                p.minionGetBuffed(target, 0, 4);
            }
        }

        


    }

}