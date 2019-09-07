using HREngine.Bots;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_999t13 : SimTemplate //* Poison Spit
	{
		//Poisonous

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            target.poisonous= true;
        }
    }
}