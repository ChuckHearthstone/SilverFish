using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._03Adventure._001NAX
{
	class Sim_NAX10_02 : SimTemplate //* Hook
	{
		//Deathrattle: Put this weapon into your hand.

        CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardIdEnum.NAX10_02);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(weapon, ownplay);
        }

        public override void onDeathrattle(Playfield p, Minion m)
        {
			p.drawACard(CardIdEnum.NAX10_02, m.own, true);
        }
    }
}