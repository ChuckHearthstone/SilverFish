using HREngine.Bots;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_132_SHAMAN : SimTemplate //* Totemic Slam
	{
		//Hero Power. Summon a Totem of your choice.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.CardIdEnum.CS2_051);//Stoneclaw Totem
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int place = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.CallKid(kid, place, ownplay, false);
        }
    }

}