using HREngine.Bots;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_077 : SimTemplate //* Argent Lance
	{
		//Battlecry : Reveal a minion in each deck. If yours costs more, gain +1 durability.

        CardDB.Card w = CardDB.Instance.getCardDataFromID(CardIdEnum.AT_077);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(w, ownplay);
        }
	}
}