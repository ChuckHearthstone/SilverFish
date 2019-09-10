using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_249 : SimTemplate //* Infested Tauren
	{
		//Taunt. Deathrattle: Summon a 2/2 Slime.
		
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.NAX11_03);
		
        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.CallKid(kid, m.zonepos - 1, m.own);
        }
	}
}