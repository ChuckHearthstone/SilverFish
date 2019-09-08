using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_554 : SimTemplate //* snaketrap
	{
        //Secret: When one of your minions is attacked, summon three 1/1 Snakes.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.EX1_554t);//snake

        public override void onSecretPlay(Playfield p, bool ownplay, int number)
        {
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.CallKid(kid, pos, ownplay, false);
            p.CallKid(kid, pos, ownplay);
            p.CallKid(kid, pos, ownplay);
        }
	}
}