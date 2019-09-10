using Chuck.SilverFish;

namespace SilverFish.cards._02Classic
{
    class Sim_EX1_046 : SimTemplate//Dark Iron Dwarf
    {
        // +2 tempattack
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null) p.minionGetTempBuff(target, 2, 0);
        }
    }
}
