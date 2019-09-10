using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_GVG_066 : SimTemplate //Dunemaul Shaman
    {
        //   Windfury, Overload: (1)

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own) p.ueberladung++;
        }
    }
}