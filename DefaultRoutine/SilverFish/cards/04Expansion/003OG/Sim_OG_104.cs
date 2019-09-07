using HREngine.Bots;

namespace SilverFish.cards._04Expansion._003OG
{
    class Sim_OG_104 : SimTemplate //* Embrace the Shadow
    {
        //This turn, your healing effects deal damage instead.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{			
            if (ownplay)
            {
                p.embracetheshadow++;
            }
		}
	}
}