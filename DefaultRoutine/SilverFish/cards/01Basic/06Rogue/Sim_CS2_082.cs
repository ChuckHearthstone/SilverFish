using HREngine.Bots;

namespace SilverFish.cards._01Basic._06Rogue
{
	class Sim_CS2_082 : SimTemplate //* wickedknife
	{
        //-

        CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardDB.CardIdEnum.CS2_082);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(weapon, ownplay);
        }
    }
}