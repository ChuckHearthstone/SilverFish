using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_273 : SimTemplate //* Stand Against Darkness
	{
		//Summon five 1/1 Silver Hand Recruits.
		
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.CS2_101t);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;

            p.CallKid(kid, pos, ownplay, false);
            for (int i = 0; i < 4; i++) p.CallKid(kid, pos, ownplay);
        }
    }
}
