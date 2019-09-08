using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._03Adventure._001NAX
{
	class Sim_NAX8_05 : SimTemplate //* Unrelenting Rider
	{
//    Deathrattle:: Summon a Spectral Rider for your opponent.
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.NAX8_05t); //Spectral Rider
		
        public override void onDeathrattle(Playfield p, Minion m)
        {
            int place = (m.own) ? p.enemyMinions.Count : p.ownMinions.Count;
            p.CallKid(kid, place, !m.own);
        }
	}
}