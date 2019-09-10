using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_096: SimTemplate //* Furnacefire Colossus
    {
        // Battlecry: Discard all weapons from your hand and gain their stats.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                int atkBuff = 0;
                int hpBuff = 0;

                foreach(Handmanager.Handcard hc in p.owncards.ToArray())
                {
                    if (hc.card.type == CardType.WEAPON)
                    {
                        atkBuff += hc.card.Attack + hc.addattack;
                        hpBuff += hc.card.Durability + hc.addHp;
                        p.owncards.Remove(hc);
                    }
                }
                if (atkBuff + hpBuff > 0) p.minionGetBuffed(own, atkBuff, hpBuff);
            }
        }
    }
}