using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_074 : SimTemplate //* Seal of Champions
	{
		//Give a minion +3 Attack and Divine Shield.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetBuffed(target, 3, 0);
			target.DivineShield = true;
        }
    }
}
