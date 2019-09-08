using HREngine.Bots;

namespace SilverFish.cards._01Basic._00Neutral
{
	class Sim_NEW1_029 : SimTemplate //millhousemanastorm
	{

//    kampfschrei:/ im nächsten zug kosten zauber für euren gegner (0) mana.
        //todo implement the nomanacosts for the enemyturn
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (own.own) p.weHavePlayedMillhouseManastorm = true;
		}


	}
}