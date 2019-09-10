using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_150 : SimTemplate //* Aberrant Berserker
	{
		//Enrage: +2 Attack.
		
        public override void onEnrageStart(Playfield p, Minion m)
        {
            m.Attack += 2;
        }

        public override void onEnrageStop(Playfield p, Minion m)
        {
            m.Attack -= 2;
        }
	}
}