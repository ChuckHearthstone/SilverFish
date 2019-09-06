using HREngine.Bots;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_752 : SimTemplate //* Stolen Goods
	{
        // Give a random Taunt minion in your hand +3/+3.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {
                Handmanager.Handcard hc = p.searchRandomMinionInHand(p.owncards, searchmode.searchLowestCost, GAME_TAGs.TAUNT);
                if (hc != null)
                {
                    hc.addattack += 3;
                    hc.addHp += 3;
                    p.anzOwnExtraAngrHp += 6;
                }
            }
        }
	}
}