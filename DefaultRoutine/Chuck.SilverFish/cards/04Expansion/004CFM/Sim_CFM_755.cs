using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_755 : SimTemplate //* Grimestreet Pawnbroker
	{
		// Battlecry: Give a random weapon in your hand +1/+1.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                Handmanager.Handcard hc = p.searchRandomMinionInHand(p.owncards, searchmode.searchLowestCost, GAME_TAGs.Weapon);
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