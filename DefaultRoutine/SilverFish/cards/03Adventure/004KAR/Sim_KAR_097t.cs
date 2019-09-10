using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._03Adventure._004KAR
{
	class Sim_KAR_097t : SimTemplate //* Atiesh
	{
        //After you cast a spell, summon a random minion of that Cost. Lose 1 Durability.

        CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardIdEnum.KAR_097t);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(weapon, ownplay);
        }
	}
}