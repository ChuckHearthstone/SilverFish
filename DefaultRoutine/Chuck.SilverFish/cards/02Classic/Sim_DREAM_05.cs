using Chuck.SilverFish;

namespace SilverFish.cards._02Classic
{
    class Sim_DREAM_05 : SimTemplate//Nightmare
    {

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetBuffed(target, 4, 4);
            if (ownplay)
            {
                target.destroyOnOwnTurnStart = true;
            }
            else
            {
                target.destroyOnEnemyTurnStart = true;
            }
        }

    }
}
