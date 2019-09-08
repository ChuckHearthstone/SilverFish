using HREngine.Bots;

namespace SilverFish.cards._03Adventure._003LOE
{
	class Sim_LOE_050 : SimTemplate //* Mounted Raptor
	{
        //Deathrattle: Summon a random 1-Cost minion.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.BRM_004); //Twilight Whelp

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.CallKid(kid, m.zonepos - 1, m.own);
        }
    }
}