using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_PART_003 : SimTemplate //* Rusty Horn
    {
        // Give a minion Taunt.  

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (!target.taunt)
            {
                target.taunt = true;
                if (target.own) p.anzOwnTaunt++;
                else p.anzEnemyTaunt++;
            }
        }
    }
}