using HREngine.Bots;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_236: SimTemplate //* Ice Breaker
    {
        // Destroy any Frozen minion damaged by this.
        //done in Playfield

        CardDB.Card w = CardDB.Instance.getCardDataFromID(CardDB.CardIdEnum.ICC_236);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(w, ownplay);
        }
    }
}