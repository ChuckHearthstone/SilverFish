using Chuck.SilverFish;

namespace SilverFish.cards._02Classic
{
    class Sim_EX1_564 : SimTemplate //facelessmanipulator
    {

        //    kampfschrei:/ wählt einen diener aus, um gesichtsloser manipulator in eine kopie desselben zu verwandeln.
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null)
            {
                //p.copyMinion(own, target);
                bool source = own.own;
                own.setMinionToMinion(target);
                own.own = source;
                own.handcard.card.CardSimulation.onAuraStarts(p, own);
            }
        }


    }
}