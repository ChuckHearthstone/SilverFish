using HREngine.Bots;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_621t38 : SimTemplate //* Ichor of Undeath
	{
		// Summon 2 friendly minions that died this game.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
			if (p.OwnLastDiedMinion != CardDB.CardIdEnum.None)
			{
				p.CallKid(CardDB.Instance.getCardDataFromID(p.OwnLastDiedMinion), pos, ownplay, false); //presurmise - OwnLastDiedMinion also for enemy
				p.CallKid(CardDB.Instance.getCardDataFromID(p.OwnLastDiedMinion), pos, ownplay);
			}
        }
    }
}