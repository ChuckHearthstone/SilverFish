using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_110 : SimTemplate //* cairnebloodhoof
	{
        //Deathrattle: Summon a 4/5 Baine Bloodhoof.

        CardDB.Card blaine = CardDB.Instance.getCardDataFromID(CardIdEnum.EX1_110t);

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.CallKid(blaine, m.zonepos-1, m.own);
        }
	}
}