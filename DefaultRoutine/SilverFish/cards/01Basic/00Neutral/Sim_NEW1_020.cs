using HREngine.Bots;

namespace SilverFish.cards._01Basic._00Neutral
{
	class Sim_NEW1_020 : SimTemplate //* Wild Pyromancer
	{
		// After you cast a spell, deal 1 damage to ALL minions.

        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool ownplay, Minion m)
        {
            if (m.own == ownplay && hc.card.type == CardDB.cardtype.SPELL) p.allMinionsGetDamage(1);
        }
	}
}