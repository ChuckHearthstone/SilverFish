using HREngine.Bots;

namespace SilverFish.cards._03Adventure._004KAR
{
	class Sim_KAR_097 : SimTemplate //* Medivh, the Guardian
	{
		//Battlecry: Equip Atiesh, Greatstaff of the Guardian.
		
        CardDB.Card wcard = CardDB.Instance.getCardDataFromID(CardIdEnum.KAR_097t);//Atiesh

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.equipWeapon(wcard, own.own);
        }
    }
}
