using HREngine.Bots;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_960 : SimTemplate //* Lost in the Jungle
	{
		//Summon two 1/1 Silver Hand Recruits.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_101t);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.CallKid(kid, pos, ownplay, false);
            p.CallKid(kid, pos, ownplay);
        }
    }
}