using HREngine.Bots;

namespace SilverFish.cards._01Basic._07Shaman
{
    class Sim_CS2_053 : SimTemplate//far sight
    {

        //todo: bonus for it?
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardDB.cardName.unknown, ownplay);
        }

    }
}
