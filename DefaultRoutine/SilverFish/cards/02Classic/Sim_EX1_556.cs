using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_556 : SimTemplate //* harvestgolem
	{
        //Deathrattle: Summon a 2/1 Damaged Golem.

        CardDB.Card card = CardDB.Instance.getCardDataFromID(CardIdEnum.skele21);

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.CallKid(card, m.zonepos - 1, m.own);
        }
	}
}