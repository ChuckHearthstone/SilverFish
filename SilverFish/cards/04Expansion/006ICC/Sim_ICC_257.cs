using HREngine.Bots;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_257: SimTemplate //* Corpse Raiser
    {
        // Battlecry: Give a friendly minion "Deathrattle: Resummon this minion."

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (target != null) target.ancestralspirit++;
		}
	}
}