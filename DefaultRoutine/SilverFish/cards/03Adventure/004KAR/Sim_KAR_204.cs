using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._03Adventure._004KAR
{
	class Sim_KAR_204 : SimTemplate //* Onyx Bishop
	{
		//Battlecry: Summon a friendly minion that died this game.
				
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (own.own)
            {
                if (p.OwnLastDiedMinion != CardIdEnum.None)
                {
                    p.CallKid(CardDB.Instance.getCardDataFromID(p.OwnLastDiedMinion), own.zonepos, own.own);
                }
            }
		}
	}
}