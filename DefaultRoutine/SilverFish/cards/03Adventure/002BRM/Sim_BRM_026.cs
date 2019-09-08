using HREngine.Bots;

namespace SilverFish.cards._03Adventure._002BRM
{
	class Sim_BRM_026 : SimTemplate //* Hungry Dragon
	{
		// Battlecry: Summon a random 1-Cost minion for your opponent.
        		
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.CardIdEnum.EX1_614t); //flameofazzinoth

		public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            int zonepos = (m.own) ? p.enemyMinions.Count : p.ownMinions.Count;
            p.CallKid(kid, zonepos, !m.own);
        }
	}
}