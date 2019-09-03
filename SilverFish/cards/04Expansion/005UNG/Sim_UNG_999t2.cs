using HREngine.Bots;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_999t2 : SimTemplate //* Living Spores
	{
		//Deathrattle: Summon two 1/1 Plants.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            target.livingspores++;
        }
    }
}