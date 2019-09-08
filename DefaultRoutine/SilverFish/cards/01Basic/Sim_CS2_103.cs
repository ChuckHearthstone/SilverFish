using HREngine.Bots;

namespace SilverFish.cards._01Basic
{
    class Sim_CS2_103 : SimTemplate //* Charge
    {
        //Give a friendly minion Charge. It can't attack heroes this turn.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetCharge(target);
            target.cantAttackHeroes = true;
        }
	}
}