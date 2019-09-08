using HREngine.Bots;

namespace SilverFish.cards._01Basic.Druid
{
    class Sim_NEW1_008a : SimTemplate //* Ancient Teachings
	{
        //Draw a card.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardDB.cardName.unknown, ownplay);
        }
    }
}