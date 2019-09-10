using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_338 : SimTemplate //* Trogg Beastrager
	{
        // Battlecry: Give a random Beast in your hand +1/+1.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                Handmanager.Handcard hc = p.searchRandomMinionInHand(p.owncards, searchmode.searchLowestCost, GAME_TAGs.CARDRACE, TAG_RACE.PET);
                if (hc != null)
                {
                    hc.addattack++;
                    hc.addHp++;
                    p.anzOwnExtraAngrHp += 2;
                }
            }
        }
	}
}