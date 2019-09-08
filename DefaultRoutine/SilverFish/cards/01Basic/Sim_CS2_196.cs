using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._01Basic
{
	class Sim_CS2_196 : SimTemplate //* razorfenhunter
	{
        //Battlecry: Summon a 1/1 Boar.
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.CS2_boar); //boar

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.CallKid(kid, own.zonepos, own.own);
		}
	}
}