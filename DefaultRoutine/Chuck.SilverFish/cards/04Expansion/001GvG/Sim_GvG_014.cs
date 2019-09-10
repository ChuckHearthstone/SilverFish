using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_GVG_014 : SimTemplate //* Vol'jin
    {
       //Battlecry: Swap Health with another minion.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target == null) return;

            own.maxHp = target.HealthPoints;
            target.maxHp = own.HealthPoints;

            own.HealthPoints = own.maxHp;
            target.HealthPoints = target.maxHp;
            if (target.wounded)
            {
                target.wounded = false;
                target.handcard.card.CardSimulation.onEnrageStop(p, target);
            }
        }
    }
}