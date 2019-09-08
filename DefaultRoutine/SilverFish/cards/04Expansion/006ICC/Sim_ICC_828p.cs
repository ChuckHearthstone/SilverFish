using HREngine.Bots;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_828p: SimTemplate //* Build-a-Beast
    {
        // Hero Power: Craft a custom Zombeast.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardDB.CardName.unknown, ownplay, true);
        }
    }
}