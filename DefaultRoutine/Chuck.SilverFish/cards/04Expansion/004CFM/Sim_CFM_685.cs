using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_685 : SimTemplate //* Don Han'Cho
	{
        // Battlecry: Give a random minion in your hand +5/+5.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                Handmanager.Handcard hc = p.searchRandomMinionInHand(p.owncards, searchmode.searchLowestCost, GAME_TAGs.Mob);
                if (hc != null)
                {
                    hc.addattack += 5;
                    hc.addHp += 5;
                    p.anzOwnExtraAngrHp += 10;
                }
            }
        }
	}
}