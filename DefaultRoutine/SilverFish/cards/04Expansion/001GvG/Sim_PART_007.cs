using HREngine.Bots;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_PART_007 : SimTemplate //Whirling Blades
    {

        //Give a minion +1 Attack.   


        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetBuffed(target, 1, 0);
        }


    }

}