using HREngine.Bots;

namespace SilverFish.cards._01Basic._01Druid
{
	class Sim_CS2_013 : SimTemplate //wildgrowth
	{

//    erhaltet einen leeren manakristall.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            if (ownplay)
            {
                if (p.ownMaxMana < 10)
                {
                    p.ownMaxMana++;
                }
                else
                {
                    p.drawACard(CardDB.cardName.excessmana, true, true);
                }

            }
            else
            {
                if (p.enemyMaxMana < 10)
                {
                    p.enemyMaxMana++;
                }
                else
                {
                    p.drawACard(CardDB.cardName.excessmana, false, true);
                }
            }
		}

	}

    class Sim_CS2_013t : SimTemplate //excessmana
    {

        //    zieht eine karte. i&gt;(ihr könnt nur 10 mana in eurer leiste haben.)/i&gt;
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardDB.cardName.unknown, ownplay);
        }

    }
}