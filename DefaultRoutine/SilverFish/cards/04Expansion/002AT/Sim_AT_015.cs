using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_015 : SimTemplate //* Convert
	{
		//Put a copy of an enemy minion into your hand.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(target.handcard.card.name, ownplay, true);
        }
    }
}
