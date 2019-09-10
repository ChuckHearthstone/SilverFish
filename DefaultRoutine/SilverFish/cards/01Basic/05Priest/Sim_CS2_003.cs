using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._01Basic._05Priest
{
    class Sim_CS2_003 : SimTemplate//Mind Vision
    {

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int anz = (ownplay) ? p.enemyAnzCards : p.owncards.Count;
            if (anz >= 1)
            {
                p.drawACard(CardName.unknown, ownplay,true);
            }
        }

    }
}
