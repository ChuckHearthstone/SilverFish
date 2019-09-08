using HREngine.Bots;

namespace SilverFish.cards._01Basic._04Paladin
{
    class Sim_CS2_087 : SimTemplate//Blessing of Might
    {
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetBuffed(target, 3, 0);
        }

    }
}
