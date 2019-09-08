using HREngine.Bots;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_208 : SimTemplate //* Stone Sentinel
	{
		//Battlecry: If you played an Elemental last turn, summon two 2/3 Elementals with Taunt.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.UNG_208t); //Rock Elemental

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
			if (p.anzOwnElementalsLastTurn > 0 && own.own)
			{
                p.CallKid(kid, own.zonepos - 1, own.own); //1st left
                p.CallKid(kid, own.zonepos, own.own);
			}
        }
    }
}