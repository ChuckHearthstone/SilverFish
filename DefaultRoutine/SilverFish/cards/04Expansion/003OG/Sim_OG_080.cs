using HREngine.Bots;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_080 : SimTemplate //* Xaril, Poisoned Mind
	{
		//Battlecry and Deathrattle: Add a random Toxin card to your hand.
		
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.drawACard(CardDB.CardName.briarthorntoxin, own.own, true);
        }

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(CardDB.CardName.fadeleaftoxin, m.own, true);
        }
    }
}