using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_065: SimTemplate //* Bone Baron
    {
        // Deathrattle: Add two 1/1 Skeletons to your hand.
        
        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(CardIdEnum.ICC_026t, m.own, true); //Skeleton 1/1
            p.drawACard(CardIdEnum.ICC_026t, m.own, true);
        }
    }
}