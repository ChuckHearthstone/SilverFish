using HREngine.Bots;

namespace SilverFish.cards._01Basic._00Neutral
{
	class Sim_PRO_001c : SimTemplate //* powerofthehorde
	{
        //Summon a random Horde Warrior.
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.EX1_390);

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.CallKid(kid, pos, ownplay, false);
		}
	}
}