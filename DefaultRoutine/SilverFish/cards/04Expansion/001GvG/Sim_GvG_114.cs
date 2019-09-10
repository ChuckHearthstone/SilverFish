using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_GVG_114 : SimTemplate //* Sneed's Old Shredder
    {

        // Deathrattle: Summon a random legendary minion.
		
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.EX1_014);

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.CallKid(kid, m.zonepos - 1, m.own); 
        }
    }
}