using HREngine.Bots;

namespace SilverFish.cards._03Adventure._004KAR
{
	class Sim_KAR_004 : SimTemplate //* Cat Trick
	{
		//Secret: After your opponent casts a spell, summon a 4/2 Panther with Stealth.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.CardIdEnum.KAR_004a);//Panther - Cat in a Hat

        public override void onSecretPlay(Playfield p, bool ownplay, int number)
        {
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
			p.CallKid(kid, pos, ownplay, false);
        }
    }
}