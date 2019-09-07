using HREngine.Bots;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_244: SimTemplate //* Desperate Stand
    {
        // Give a minion: "Deathrattle: Revive this minion with one Health."

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            target.desperatestand++;
        }
    }
}