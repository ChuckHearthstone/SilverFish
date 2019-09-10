using Chuck.SilverFish;

namespace SilverFish.cards._01Basic._01Druid
{
    class Sim_CS2_009 : SimTemplate //* Mark of the Wild
    {
        //Give a minion Taunt and +2/+2. (+2 Attack/+2 Health)

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetBuffed(target, 2, 2);
            if (!target.taunt)
            {
                target.taunt = true;
                if (target.own) p.anzOwnTaunt++;
                else p.anzEnemyTaunt++;
            }
        }
    }
}
