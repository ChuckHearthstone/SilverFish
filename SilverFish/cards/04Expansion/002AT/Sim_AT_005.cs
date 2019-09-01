using HREngine.Bots;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_005 : SimTemplate //* Polymorph: Boar
	{
		//Transform a minion into a 4/2 Boar with Charge.

        CardDB.Card boar = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_005t);//Boar 4/2

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionTransform(target, boar);
        }
    }
}