using HREngine.Bots;

namespace SilverFish.cards._03Adventure._001NAX
{
	class Sim_NAX8_04 : SimTemplate //* Unrelenting Warrior
	{
//    Deathrattle:: Summon a Spectral Warrior for your opponent.
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.NAX8_04t); //Spectral Warrior
		
        public override void onDeathrattle(Playfield p, Minion m)
        {
            int place = (m.own) ? p.enemyMinions.Count : p.ownMinions.Count;
            p.CallKid(kid, place, !m.own);
        }
	}
}