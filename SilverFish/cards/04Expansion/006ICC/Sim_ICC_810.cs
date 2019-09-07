using HREngine.Bots;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_810: SimTemplate //* Deathaxe Punisher
    {
        // Battlecry: Give a random Lifesteal minion in your hand +2/+2.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                Handmanager.Handcard hc = p.searchRandomMinionInHand(p.owncards, searchmode.searchLowestCost, GAME_TAGs.LIFESTEAL);
                if (hc != null)
                {
                    hc.addattack += 2;
                    hc.addHp += 2;
                    p.anzOwnExtraAngrHp += 4;
                }
            }
        }
    }
}