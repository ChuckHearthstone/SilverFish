using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_083 : SimTemplate //* Devilsaur Egg
	{
		//Deathrattle: Summon a 5/5 Devilsaur.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.UNG_083t1); //5/5 Devilsaur
        
        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.CallKid(kid, m.zonepos-1, m.own);
        }
	}
}