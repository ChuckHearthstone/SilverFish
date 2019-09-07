using HREngine.Bots;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_011 : SimTemplate //* Hydrologist
	{
		//Battlecry: Discover a Secret.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardDB.cardName.unknown, ownplay, true);
        }
    }
}