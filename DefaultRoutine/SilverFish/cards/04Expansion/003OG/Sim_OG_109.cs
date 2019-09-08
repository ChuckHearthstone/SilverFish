using HREngine.Bots;

namespace SilverFish.cards._04Expansion._003OG
{
    class Sim_OG_109 : SimTemplate //* Darkshire Librarian
    {
        //Battlecry: Discard a random card. Deathrattle: Draw a card.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(CardDB.CardName.unknown, m.own);
        }

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.discardCards(1, own.own);
        }
    }
}