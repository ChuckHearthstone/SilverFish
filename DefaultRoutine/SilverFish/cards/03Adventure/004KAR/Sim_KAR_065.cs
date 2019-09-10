using Chuck.SilverFish;

namespace SilverFish.cards._03Adventure._004KAR
{
	class Sim_KAR_065 : SimTemplate //* Menagerie Warden
	{
		//Battlecry: Choose a friendly Beast. Summon a copy of it.
		
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null && own.own && p.ownMinions.Count < 7)
            {
                int pos = p.ownMinions.Count;
                p.CallKid(own.handcard.card, pos, own.own);
                p.ownMinions[pos].setMinionToMinion(target);
            }
        }
    }
}