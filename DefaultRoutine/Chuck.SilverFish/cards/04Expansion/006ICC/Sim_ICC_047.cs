using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_047 : SimTemplate //* Fatespinner in hand
    {
        // Choose a Deathrattle (Secretly) - Deal 3 damage to all minions; or Give them +2/+2.
        
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            int pen = 0;
            switch (choice)
            {
                case 1:
                    if (p.ownMinions.Count + 2 > p.enemyMinions.Count) pen = -5;
                    else pen = 5;
                    break;
                case 2:
                    if (p.enemyMinions.Count >= p.ownMinions.Count) pen = -8;
                    break;
            }
            p.evaluatePenality += pen;
        }
    }
}