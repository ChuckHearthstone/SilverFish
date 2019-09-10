using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_999t6 : SimTemplate //* Massive
	{
		//Taunt

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (!target.taunt)
            {
                target.taunt = true;
                if (target.own) p.anzOwnTaunt++;
                else p.anzEnemyTaunt++;
            }
        }
    }
}