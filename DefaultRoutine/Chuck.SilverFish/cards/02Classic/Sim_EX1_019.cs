using Chuck.SilverFish;

namespace SilverFish.cards._02Classic
{
    class Sim_EX1_019 : SimTemplate //shatteredsuncleric
    {

        //    kampfschrei:/ verleiht einem befreundeten diener +1/+1.
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null) p.minionGetBuffed(target, 1, 1);
        }


    }
}