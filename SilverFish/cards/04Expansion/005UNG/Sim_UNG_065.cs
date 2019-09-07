using HREngine.Bots;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_065 : SimTemplate //* Sherazin, Corpse Flower
	{
		//Deathrattle: Go dormant. Play 4 cards in a turn to revive this minion.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.UNG_065t); //Sherazin, Seed

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.CallKid(kid, m.zonepos - 1, m.own);
        }
    }
}