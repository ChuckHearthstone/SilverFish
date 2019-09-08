using HREngine.Bots;

namespace SilverFish.cards._03Adventure._001NAX
{
	class Sim_NAX12_03H : SimTemplate //* 3/5 Jaws
	{
		//Whenever a minion with Deathrattle dies, gain +2
		//Handled in triggerAMinionDied()
		
        CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardIdEnum.NAX12_03H);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(weapon, ownplay);
        }
    }
}