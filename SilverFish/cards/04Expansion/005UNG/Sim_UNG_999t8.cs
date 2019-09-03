using HREngine.Bots;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_999t8 : SimTemplate //* Crackling Shield
	{
		//Divine Shield

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
			target.divineshild = true;
        }
    }
}