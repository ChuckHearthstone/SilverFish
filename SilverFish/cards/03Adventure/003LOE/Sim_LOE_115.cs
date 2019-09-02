using HREngine.Bots;

namespace SilverFish.cards._03Adventure._003LOE
{
	class Sim_LOE_115 : SimTemplate //* Raven Idol
	{
		//Choose one - Discover a minion; or Discover a spell.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            if (choice == 1 || (p.ownFandralStaghelm > 0 && ownplay))
            {
                p.drawACard(CardDB.cardName.lepergnome, ownplay, true);
            }
            if (choice == 2 || (p.ownFandralStaghelm > 0 && ownplay))
            {
                p.drawACard(CardDB.cardName.thecoin, ownplay, true);
            }
		}
	}
}