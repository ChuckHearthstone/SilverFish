using HREngine.Bots;

namespace SilverFish.cards._01Basic._00Neutral
{
	class Sim_GAME_005 : SimTemplate //thecoin
	{

//    erhaltet 1 manakristall nur für diesen zug.
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {
                p.mana++;
            }
            else
            {
                p.mana++;
            }
        }

	}
}