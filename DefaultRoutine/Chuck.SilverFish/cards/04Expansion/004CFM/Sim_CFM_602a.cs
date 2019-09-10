using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_602a : SimTemplate //* Jade Idol
	{
		// Summon a Jade Golem.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.CallKid(p.getNextJadeGolem(ownplay), pos, ownplay);
        }
    }
}