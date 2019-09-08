using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_648 : SimTemplate //* Big-Time Racketeer
	{
		// Battlecry: Summon a 6/6 Ogre.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.CFM_648t); //6/6 Ogre

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            p.CallKid(kid, m.zonepos, m.own);
        }
    }
}