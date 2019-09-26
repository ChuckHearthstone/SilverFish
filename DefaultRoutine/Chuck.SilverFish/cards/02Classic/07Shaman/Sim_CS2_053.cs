using SilverFish.Enums;

namespace Chuck.SilverFish.cards._02Classic._07Shaman
{
    class Sim_CS2_053 : SimTemplate//far sight
    {

        //todo: bonus for it?
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardName.unknown, ownplay);
        }

    }
}
