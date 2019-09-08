using HREngine.Bots;

namespace SilverFish.cards._03Adventure._001NAX
{
	class Sim_NAX8_02 : SimTemplate //* Harvest
	{

//    Hero PowerDraw a card.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardDB.CardName.unknown, ownplay);
        }
	}
}