using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_GVG_076 : SimTemplate //Explosive Sheep
    {

        //  Deathrattle: Deal 2 damage to all minions. 

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.allMinionsGetDamage(2);
        }


    }

}